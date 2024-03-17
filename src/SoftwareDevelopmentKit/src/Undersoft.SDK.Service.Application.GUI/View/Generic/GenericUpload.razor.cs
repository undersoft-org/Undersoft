using Microsoft.FluentUI.AspNetCore.Components;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic
{
    public partial class GenericUpload : ViewItem
    {
        FluentInputFile? myFileByStream = default!;
        int progressPercent;
        string? progressTitle;

        [Parameter]
        public string DisplayName {  get; set; } = default!;

        List<string> Files = new();

        async Task OnFileUploadedAsync(FluentInputFileEventArgs file)
        {
            progressPercent = file.ProgressPercent;
            progressTitle = file.ProgressTitle;

            var localFile = Path.GetRandomFileName() + "-" + file.Name;
            Data.Model.Proxy[Rubric.RubricId] = localFile;
            Files.Add(localFile);

            // Write to the FileStream
            // See other samples: https://docs.microsoft.com/en-us/aspnet/core/blazor/file-uploads
            await using FileStream fs = new(localFile, FileMode.Create);
            await file.Stream!.CopyToAsync(fs);
            await file.Stream!.DisposeAsync();
        }

        void OnCompleted(IEnumerable<FluentInputFileEventArgs> files)
        {
            progressPercent = myFileByStream!.ProgressPercent;
            progressTitle = myFileByStream!.ProgressTitle;
        }
    }
}
