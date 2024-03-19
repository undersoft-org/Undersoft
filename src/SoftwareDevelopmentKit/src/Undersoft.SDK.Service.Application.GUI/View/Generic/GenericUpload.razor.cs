using Microsoft.FluentUI.AspNetCore.Components;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic
{
    public partial class GenericUpload : ViewItem
    {
        FluentInputFile? FileByStream = default!;
        int progressPercent;
        string? progressTitle;

        [Parameter]
        public string DisplayName { get; set; } = default!;

        List<string> Files = new();

        protected override void OnInitialized()
        {
            var filename = Data.Model.Proxy[Rubric.RubricId];
            if (filename != null)
                Files.Add(filename.ToString()!.Split(';')[2]);

            base.OnInitialized();
        }

        async Task OnFileUploadedAsync(FluentInputFileEventArgs file)
        {
            Files.Clear();

            progressPercent = file.ProgressPercent;
            progressTitle = file.ProgressTitle;

            var localFile = $"data:{file.ContentType};name:{file.Name}";
            Data.Model.Proxy[Rubric.RubricId] = localFile;
            Files.Add(file.Name);

            await using FileStream fs = new(localFile, FileMode.Create);

            if (Rubric.DataRubricName != null)
            {
                var bytes = await file.Stream!.GetAllBytesAsync();
                Data.Model.Proxy[Rubric.DataRubricName] = bytes;
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }
            else
                await file.Stream!.CopyToAsync(fs);

            await file.Stream!.DisposeAsync();
        }

        void OnCompleted(IEnumerable<FluentInputFileEventArgs> files)
        {
            progressPercent = FileByStream!.ProgressPercent;
            progressTitle = FileByStream!.ProgressTitle;
        }
    }
}
