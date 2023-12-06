﻿namespace Undersoft.SDK.Invoking.Work.Notes
{
    using System.Linq;
    using Series;

    public enum EvokerType
    {
        None,
        Always,
        Single,
        Schedule
    }

    public class WorkNotes : Catalog<WorkNoteBox>
    {
        private Case Case { get; set; }

        private void send(WorkNote parameters)
        {
            if (parameters.RecipientName != null && parameters.SenderName != null)
            {
                if (ContainsKey(parameters.RecipientName))
                {
                    WorkNoteBox iobox = Get(parameters.RecipientName);
                    if (iobox != null)
                        iobox.Notify(parameters);
                }
                else if (parameters.Recipient != null)
                {
                    WorkItem labor = parameters.Recipient;
                    WorkNoteBox iobox = new WorkNoteBox(labor.Worker.Name);
                    iobox.Work = labor;
                    iobox.Notify(parameters);
                    SetOutbox(iobox);
                }
                else if (Case != null)
                {
                    var labors = Case.AsValues()
                        .Where(m => m.ContainsKey(parameters.RecipientName))
                        .SelectMany(os => os.AsValues());

                    if (labors.Any())
                    {
                        WorkItem labor = labors.FirstOrDefault();
                        WorkNoteBox iobox = new WorkNoteBox(labor.Worker.Name);
                        iobox.Work = labor;
                        iobox.Notify(parameters);
                        SetOutbox(iobox);
                    }
                }
            }
        }

        public void Send(params WorkNote[] parametersList)
        {
            foreach (WorkNote parameters in parametersList)
            {
                send(parameters);
            }
        }

        public void SetOutbox(WorkNoteBox value)
        {
            if (value != null)
            {
                if (value.Work != null)
                {
                    Put(value.RecipientName, value);
                }
                else
                {
                    var labors = Case.AsValues()
                        .Where(m => m.ContainsKey(value.RecipientName))
                        .SelectMany(os => os.AsValues());

                    if (labors.Any())
                    {
                        WorkItem labor = labors.First();
                        value.Work = labor;
                        Put(value.RecipientName, value);
                    }
                }
            }
        }

        public void CreateOutbox(string key, WorkNoteBox noteBox)
        {
            if (noteBox != null)
            {
                if (noteBox.Work != null)
                {
                    WorkItem labor = noteBox.Work;
                    Put(noteBox.RecipientName, noteBox);
                }
                else
                {
                    var labors = Case.AsValues()
                        .Where(m => m.ContainsKey(key))
                        .SelectMany(os => os.AsValues());

                    if (labors.Any())
                    {
                        WorkItem labor = labors.FirstOrDefault();
                        noteBox.Work = labor;
                        Put(key, noteBox);
                    }
                }
            }
            else
            {
                var labors = Case.AsValues()
                    .Where(m => m.ContainsKey(key))
                    .SelectMany(os => os.AsValues());

                if (labors.Any())
                {
                    WorkItem labor = labors.FirstOrDefault();
                    WorkNoteBox iobox = new WorkNoteBox(labor.Worker.Name);
                    iobox.Work = labor;
                    Put(key, iobox);
                }
            }
        }
    }
}
