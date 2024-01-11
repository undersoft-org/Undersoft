﻿using System.Collections.Concurrent;

namespace Undersoft.SDK.Service.Application.Components;

public partial class Table<TItem>
{
    protected string? SortName { get; set; }

    protected SortOrder SortOrder { get; set; }

    [Parameter]
    [NotNull]
    public string? SortIconAsc { get; set; }

    [Parameter]
    [NotNull]
    public string? SortIconDesc { get; set; }

    [Parameter]
    [NotNull]
    public string? SortIcon { get; set; }

    [Parameter]
    public string? FilterIcon { get; set; }

    [Parameter]
    public string? SortString { get; set; }

    [Parameter]
    public Func<string, SortOrder, string>? OnSort { get; set; }

    [NotNull]
    protected Func<string, SortOrder, Task>? InternalOnSortAsync { get; set; }

    protected Func<Task> OnClickHeader(ITableColumn col) => async () =>
    {
        UpdateSortTooltip = true;

        if (SortOrder == SortOrder.Unset)
        {
            SortOrder = SortOrder.Asc;
        }
        else if (SortOrder == SortOrder.Asc)
        {
            SortOrder = SortOrder.Desc;
        }
        else if (SortOrder == SortOrder.Desc)
        {
            SortOrder = SortOrder.Unset;
        }

        SortName = col.GetFieldName();

        await InternalOnSortAsync(SortName, SortOrder);
    };

    protected string? GetHeaderClassString(ITableColumn col, bool isFilterHeader = false) => CssBuilder.Default()
        .AddClass("sortable", col.Sortable && !isFilterHeader)
        .AddClass("filterable", col.Filterable)
        .AddClass(GetFixedCellClassString(col))
        .Build();

    protected string? GetHeaderCellClassString(ITableColumn col) => CssBuilder.Default()
        .AddClass("table-text")
        .AddClass("text-truncate", col.HeaderTextEllipsis)
        .AddClass("text-wrap", HeaderTextWrap || col.HeaderTextWrap)
        .Build();

    private string? MultiColumnClassString => CssBuilder.Default()
        .AddClass("fixed", FixedMultipleColumn)
        .AddClass("fr", IsLastMultiColumn())
        .Build();

    private string? DetailColumnClassString => CssBuilder.Default()
        .AddClass("fixed", FixedDetailRowHeaderColumn)
        .AddClass("fr", IsLastDetailColumn())
        .Build();

    private string? LineNoColumnClassString => CssBuilder.Default()
        .AddClass("fixed", FixedLineNoColumn)
        .AddClass("fr", IsLastLineNoColumn())
        .Build();

    private int LineNoColumnLeft()
    {
        var left = 0;
        if (GetFixedDetailRowHeaderColumn && GetFixedMultipleSelectColumn)
        {
            left = DetailColumnWidth + MultiColumnWidth;
        }
        else if (GetFixedMultipleSelectColumn)
        {
            left = MultiColumnWidth;
        }
        else if (GetFixedDetailRowHeaderColumn)
        {
            left = DetailColumnWidth;
        }
        return left;
    }

    private int MultipleSelectColumnLeft()
    {
        var left = 0;
        if (GetFixedDetailRowHeaderColumn)
        {
            left = DetailColumnWidth;
        }
        return left;
    }

    private bool GetFixedDetailRowHeaderColumn => FixedDetailRowHeaderColumn && ShowDetails();

    private bool GetFixedMultipleSelectColumn => FixedMultipleColumn && IsMultipleSelect;

    private bool GetFixedLineNoColumn => FixedLineNoColumn && ShowLineNo;

    private string? DetailColumnStyleString => GetFixedDetailRowHeaderColumn ? "left: 0;" : null;

    private string? LineNoColumnStyleString => GetFixedLineNoColumn ? $"left: {LineNoColumnLeft()}px;" : null;

    private string? MultiColumnStyleString => GetFixedMultipleSelectColumn ? $"left: {MultipleSelectColumnLeft()}px;" : null;

    private int MultiColumnWidth => ShowCheckboxText ? ShowCheckboxTextColumnWidth : CheckboxColumnWidth;

    protected string? GetFixedCellClassString(ITableColumn col, string? cellClass = null) => CssBuilder.Default(cellClass)
        .AddClass("fixed", col.Fixed)
        .AddClass("fixed-right", col.Fixed && IsTail(col))
        .AddClass("fr", IsLastColumn(col))
        .AddClass("fl", IsFirstColumn(col))
        .Build();

    protected string? FixedExtendButtonsColumnClassString => CssBuilder.Default("table-column-button")
        .AddClass("fixed", FixedExtendButtonsColumn)
        .AddClass("fixed-right", !IsExtendButtonsInRowHeader)
        .AddClass("fr", IsLastExtendButtonColumn())
        .AddClass("fl", IsFirstExtendButtonColumn())
        .Build();

    protected string? ExtendButtonsColumnClass => CssBuilder.Default()
        .AddClass("fixed", FixedExtendButtonsColumn)
        .AddClass("fixed-right", !IsExtendButtonsInRowHeader)
        .AddClass("fr", IsLastExtendButtonColumn())
        .AddClass("fl", IsFirstExtendButtonColumn())
        .Build();

    protected string? GetFixedExtendButtonsColumnStyleString(int margin = 0) => CssBuilder.Default()
        .AddClass($"right: {(IsFixedHeader ? margin : 0)}px;", FixedExtendButtonsColumn && !IsExtendButtonsInRowHeader)
        .AddClass($"left: {GetExtendButtonsColumnLeftMargin()}px;", FixedExtendButtonsColumn && IsExtendButtonsInRowHeader)
        .Build();

    private bool IsLastDetailColumn() => !GetFixedMultipleSelectColumn && !GetFixedLineNoColumn && IsNotFixedColumn();

    private bool IsLastMultiColumn() => !GetFixedLineNoColumn && IsNotFixedColumn();

    private bool IsLastLineNoColumn() => IsNotFixedColumn();

    private bool IsNotFixedColumn() => !(FixedExtendButtonsColumn && IsExtendButtonsInRowHeader) && !(GetVisibleColumns().FirstOrDefault()?.Fixed ?? false);

    private ConcurrentDictionary<ITableColumn, bool> LastFixedColumnCache { get; } = new();

    private bool IsLastColumn(ITableColumn col) => LastFixedColumnCache.GetOrAdd(col, col =>
    {
        var ret = false;
        if (col.Fixed && !IsTail(col))
        {
            var index = Columns.IndexOf(col) + 1;
            ret = index < Columns.Count && Columns[index].Fixed == false;
        }
        return ret;
    });

    private bool IsLastExtendButtonColumn() => IsExtendButtonsInRowHeader && !GetVisibleColumns().Any(i => i.Fixed);

    private ConcurrentDictionary<ITableColumn, bool> FirstFixedColumnCache { get; } = new();

    private bool IsFirstColumn(ITableColumn col) => FirstFixedColumnCache.GetOrAdd(col, col =>
    {
        var ret = false;
        if (col.Fixed && IsTail(col))
        {
            var index = Columns.IndexOf(col) - 1;
            if (index > 0)
            {
                ret = !Columns[index].Fixed;
            }
        }
        return ret;
    });

    private bool IsFirstExtendButtonColumn() => !IsExtendButtonsInRowHeader && !GetVisibleColumns().Any(i => i.Fixed);

    private int GetExtendButtonsColumnLeftMargin()
    {
        var width = 0;
        if (ShowDetails())
        {
            width += DetailColumnWidth;
        }
        if (ShowLineNo)
        {
            width += LineNoColumnWidth;
        }
        if (FixedMultipleColumn)
        {
            width += MultiColumnWidth;
        }
        return width;
    }

    private int CalcMargin(int margin)
    {
        if (ShowDetails())
        {
            margin += DetailColumnWidth;
        }
        if (IsMultipleSelect)
        {
            margin += ShowCheckboxText ? ShowCheckboxTextColumnWidth : CheckboxColumnWidth;
        }
        if (ShowLineNo)
        {
            margin += LineNoColumnWidth;
        }
        return margin;
    }

    private bool IsTail(ITableColumn col)
    {
        var middle = Math.Floor(GetVisibleColumns().Count() * 1.0 / 2);
        var index = Columns.IndexOf(col);
        return middle < index;
    }

    protected string? GetCellStyleString(ITableColumn col) => col.TextEllipsis && !AllowResizing ? $"width: {col.Width ?? 200}px" : null;

    protected string? GetFixedCellStyleString(ITableColumn col, int margin = 0)
    {
        var style = CssBuilder.Default();
        if (col.Fixed)
        {
            var defaultWidth = 200;
            var isTail = IsTail(col);
            var index = Columns.IndexOf(col);
            var width = 0;
            var start = 0;
            if (isTail)
            {
                while (index + 1 < Columns.Count)
                {
                    width += Columns[index++].Width ?? defaultWidth;
                }
                if (ShowExtendButtons && FixedExtendButtonsColumn)
                {
                    width += ExtendButtonColumnWidth;
                }

                if (IsFixedHeader && (index + 1) == Columns.Count)
                {
                    width += margin;
                }

                style.AddClass($"right: {width}px;");
            }
            else
            {
                if (GetFixedDetailRowHeaderColumn)
                {
                    width += DetailColumnWidth;
                }
                if (GetFixedMultipleSelectColumn)
                {
                    width += MultiColumnWidth;
                }
                if (GetFixedLineNoColumn)
                {
                    width += LineNoColumnWidth;
                }
                while (index > start)
                {
                    width += Columns[start++].Width ?? defaultWidth;
                };
                style.AddClass($"left: {width}px;");
            }
        }
        return style.Build();
    }

    protected string? GetHeaderWrapperClassString(ITableColumn col) => CssBuilder.Default("table-cell")
        .AddClass("is-sort", col.Sortable)
        .AddClass("is-filter", col.Filterable)
        .AddClass(col.Align.ToDescriptionString(), col.Align == Alignment.Center || col.Align == Alignment.Right)
        .Build();

    protected string? GetCellClassString(ITableColumn col, bool hasChildren, bool inCell) => CssBuilder.Default("table-cell")
        .AddClass(col.Align.ToDescriptionString(), col.Align == Alignment.Center || col.Align == Alignment.Right)
        .AddClass("is-wrap", col.TextWrap)
        .AddClass("is-ellips", col.TextEllipsis)
        .AddClass("is-tips", col.ShowTips)
        .AddClass("is-resizable", AllowResizing)
        .AddClass("is-tree", IsTree && hasChildren)
        .AddClass("is-incell", inCell)
        .AddClass(col.CssClass)
        .Build();

    protected string? GetIconClassString(string fieldName) => CssBuilder.Default("sort-icon")
        .AddClass(SortIcon, SortName != fieldName || SortOrder == SortOrder.Unset)
        .AddClass(SortIconAsc, SortName == fieldName && SortOrder == SortOrder.Asc)
        .AddClass(SortIconDesc, SortName == fieldName && SortOrder == SortOrder.Desc)
        .Build();
}
