﻿namespace Undersoft.SDK.Workflows
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Uniques;
    using Notes;
    using Undersoft.SDK;
    using Undersoft.SDK.Invoking;

    public class WorkItem : Origin, IInvoker, IWorker
    {
        public IUnique Empty => Uscn.Empty;

        public WorkItem(IInvoker operation)
        {
            Name = operation.Name;
            Worker = new Worker(operation.Name, operation);
            Worker.Work = this;
            Box = new WorkNoteBox(Worker.Name);
            Box.Work = this;

            Id = Name.UniqueKey();
            TypeId = Unique.NewId;
        }

        public WorkItem(Worker worker)
        {
            Name = worker.Name;
            Worker = worker;
            Worker.Work = this;
            Box = new WorkNoteBox(Worker.Name);
            Box.Work = this;

            Id = Name.UniqueKey();
            TypeId = Unique.NewId;
        }

        public string Name { get; set; }

        public string QualifiedName { get; set; }

        public Worker Worker { get; set; }

        public WorkAspect Aspect { get; set; }

        public WorkAspects Case { get; set; }

        public WorkNoteBox Box { get; set; }

        public object[] ParameterValues
        {
            get => Worker.Process.ParameterValues;
            set => Worker.Process.ParameterValues = value;
        }
        public object this[int fieldId]
        {
            get => ParameterValues[fieldId];
            set => ParameterValues[fieldId] = value;
        }
        public object this[string propertyName]
        {
            get
            {
                for (int i = 0; i < Parameters.Length; i++)
                    if (Parameters[i].Name == propertyName)
                        return ParameterValues[i];
                return null;
            }
            set
            {
                for (int i = 0; i < Parameters.Length; i++)
                    if (Parameters[i].Name == propertyName)
                        ParameterValues[i] = value;
            }
        }

        public MethodInfo Info
        {
            get => Worker.Process.Info;
            set => Worker.Process.Info = value;
        }

        public ParameterInfo[] Parameters
        {
            get => Worker.Process.Parameters;
            set => Worker.Process.Parameters = value;
        }
        public object[] ValueArray
        {
            get => ParameterValues;
            set => ParameterValues = value;
        }

        public InvokerDelegate MethodInvoker => Process.MethodInvoker;

        public Delegate Method => Process.Method;

        public WorkAspect Run(params object[] input)
        {
            Worker.SetInput(input);
            Aspect.Run(this);
            return Aspect;
        }

        public object Invoke(params object[] parameters)
        {
            Run(parameters);
            return null;
        }

        public Task<object> InvokeAsync(params object[] parameters)
        {
            return Task.Run(() =>
            {
                return Invoke(parameters);
            });
        }

        public Task<T> InvokeAsync<T>(params object[] parameters)
        {
            return Task.Run(() =>
            {
                Invoke(parameters);
                return default(T);
            });
        }

        public WorkNoteEvokers Evokers
        {
            get => Worker.Evokers;
            set => Worker.Evokers = value;
        }

        public string WorkerName
        {
            get => Worker.Name;
            set => Worker.Name = value;
        }

        public IInvoker Process
        {
            get => Worker.Process;
            set => Worker.Process = value;
        }
     
        public object TargetObject
        {
            get => Process.TargetObject;
            set => Process.TargetObject = value;
        }

        public WorkAspect FlowTo<T>(string methodName = null)
        {
            if (methodName == null)
                methodName = typeof(T).GetMethods().FirstOrDefault(m => m.IsPublic).Name;

            FlowTo(typeof(T).FullName, methodName);
            return Aspect;
        }

        public WorkAspect FlowTo<T>(Func<T, Delegate> methodName) where T : class, new()
        {
            string name = null;
            if (methodName == null)
                name = typeof(T).GetMethods().FirstOrDefault(m => m.IsPublic).Name;
            else
            {
                name = methodName(new T()).Method.Name;
            }

            FlowTo(typeof(T).FullName, name);
            return Aspect;
        }

        public WorkAspect FlowTo(WorkItem Recipient)
        {
            long recipientKey = Recipient.Name.UniqueKey();

            var relationWorks = Aspect
                .AsValues()
                .Where(l => l.Worker.Evokers.ContainsKey(l.Name.UniqueKey(recipientKey)))
                .ToArray();

            var evokers = relationWorks
                .Select(l => l.Evokers.Get(l.Name.UniqueKey(recipientKey)))
                .ToArray();
            foreach (var noteEvoker in evokers)
            {
                noteEvoker.RelatedWorks.Put(this);
                noteEvoker.RelatedWorkNames.Put(Name);
            }

            Worker.FlowTo(Recipient, relationWorks.Concat(new[] { this }).ToArray());

            return Aspect;
        }

        public WorkAspect FlowTo(WorkItem Recipient, params WorkItem[] RelationWorks)
        {
            Worker.FlowTo(Recipient, RelationWorks.Concat(new[] { this }).ToArray());
            return Aspect;
        }

        public WorkAspect FlowTo(string RecipientName, string methodName)
        {
            var recipient = Case
                .Where(m => m.ContainsKey(RecipientName + "." + methodName))
                .SelectMany(os => os.AsValues())
                .FirstOrDefault();

            long recipientKey = recipient.Name.UniqueKey();

            var relationWorks = Aspect
                .Where(l => l.Worker.Evokers.ContainsKey(l.Name.UniqueKey(recipientKey)))
                .ToArray();

            var evokers = relationWorks
                .Select(l => l.Evokers.Get(l.Name.UniqueKey(recipientKey)))
                .ToArray();
            foreach (var noteEvoker in evokers)
            {
                noteEvoker.RelatedWorks.Put(this);
                noteEvoker.RelatedWorkNames.Put(Name);
            }

            Worker.FlowTo(recipient, relationWorks.Concat(new[] { this }).ToArray());
            return Aspect;
        }

        public WorkAspect FlowTo(string RecipientName, params string[] RelationNames)
        {
            Worker.FlowTo(RecipientName, RelationNames.Concat(new[] { Name }).ToArray());
            return Aspect;
        }

        public WorkAspect FlowFrom<T>(string methodName = null)
        {
            if (methodName == null)
                methodName = typeof(T).GetMethods().FirstOrDefault(m => m.IsPublic).Name;

            FlowFrom(typeof(T).FullName, methodName);
            return Aspect;
        }

        public WorkAspect FlowFrom<T>(Func<T, Delegate> methodName) where T : class, new()
        {
            string name = null;
            if (methodName == null)
                name = typeof(T).GetMethods().FirstOrDefault(m => m.IsPublic).Name;
            else
            {
                name = methodName(new T()).Method.Name;
            }

            FlowFrom(typeof(T).FullName, name);
            return Aspect;
        }

        public WorkAspect FlowFrom(WorkItem Sender)
        {
            Sender.FlowTo(this);
            return Aspect;
        }

        public WorkAspect FlowFrom(WorkItem Sender, params WorkItem[] RelationWorks)
        {
            Sender.FlowTo(this, RelationWorks);
            return Aspect;
        }

        public WorkAspect FlowFrom(string SenderName, string methodName)
        {
            var sender = Case
                .Where(m => m.ContainsKey(SenderName + "." + methodName))
                .SelectMany(os => os)
                .FirstOrDefault();

            sender.FlowTo(this);
            return Aspect;
        }

        public WorkAspect FlowFrom(string SenderName, params string[] RelationNames)
        {
            var sender = Case.AsValues()
                .Where(m => m.ContainsKey(SenderName))
                .SelectMany(os => os.AsValues())
                .FirstOrDefault();

            sender.FlowTo(Name, RelationNames);
            return Aspect;
        }

        public virtual WorkAspect AddWork<T>() where T : class
        {
            return Aspect.AddWork<T>();
        }

        public virtual WorkAspect AddWork<T>(Type[] arguments) where T : class
        {
            return Aspect.AddWork<T>(arguments);
        }

        public virtual WorkAspect AddWork<T>(params object[] consrtuctorParams) where T : class
        {
            return Aspect.AddWork<T>(consrtuctorParams);
        }

        public virtual WorkAspect AddWork<T>(Type[] arguments, params object[] consrtuctorParams)
            where T : class
        {
            return Aspect.AddWork<T>(arguments, consrtuctorParams);
        }

        public virtual WorkAspect AddWork<T>(Func<T, string> method) where T : class
        {
            return Aspect.AddWork<T>(method);
        }

        public virtual WorkAspect AddWork<T>(Func<T, string> method, params Type[] arguments)
            where T : class
        {
            return Aspect.AddWork<T>(method, arguments);
        }

        public virtual WorkAspect AddWork<T>(Func<T, string> method, params object[] constructorParams)
            where T : class
        {
            return Aspect.AddWork<T>(method, constructorParams);
        }

        public virtual WorkItem Work<T>() where T : class
        {
            return Aspect.Work<T>();
        }

        public virtual WorkItem Work<T>(Type[] arguments) where T : class
        {
            return Aspect.Work<T>(arguments);
        }

        public virtual WorkItem Work<T>(params object[] consrtuctorParams) where T : class
        {
            return Aspect.Work<T>(consrtuctorParams);
        }

        public virtual WorkItem Work<T>(Type[] arguments, params object[] consrtuctorParams)
            where T : class
        {
            return Aspect.Work<T>(arguments, consrtuctorParams);
        }

        public virtual WorkItem Work<T>(Func<T, string> method) where T : class
        {
            return Aspect.Work<T>(method);
        }

        public virtual WorkItem Work<T>(Func<T, string> method, params Type[] arguments)
            where T : class
        {
            return Aspect.Work<T>(method, arguments);
        }

        public virtual WorkItem Work<T>(Func<T, string> method, params object[] constructorParams)
            where T : class
        {
            return Aspect.Work<T>(method, constructorParams);
        }

        public WorkAspect Allocate(int laborsCount = 1)
        {
            return Aspect.Allocate(laborsCount);
        }

        public object GetInput()
        {
            return ((IWorker)Worker).GetInput();
        }

        public void SetInput(object value)
        {
            ((IWorker)Worker).SetInput(value);
        }

        public object GetOutput()
        {
            return ((IWorker)Worker).GetOutput();
        }

        public void SetOutput(object value)
        {
            ((IWorker)Worker).SetOutput(value);
        }

        public Task Publish(params object[] parameters)
        {
            return Process.Publish(parameters);
        }

        public object Execute(object target, params object[] parameters)
        {
            return Process.Invoke(target, parameters);
        }

        public Task<object> ExecuteAsync(object target, params object[] parameters)
        {
            return Process.InvokeAsync(target, parameters);
        }

        public Task<T> ExecuteAsync<T>(object target, params object[] parameters)
        {
            return Process.InvokeAsync<T>(target, parameters);
        }

        public Task Publish(bool firstAsTarget, object target, params object[] parameters)
        {
            return Process.Publish(firstAsTarget, target, parameters);
        }

        public object Invoke(bool firstAsTarget, object target, params object[] parameters)
        {
            return Process.Invoke(firstAsTarget, target, parameters);
        }

        public Task<object> InvokeAsync(
            bool firstAsTarget,
            object target,
            params object[] parameters
        )
        {
            return Process.InvokeAsync(firstAsTarget, target, parameters);
        }

        public Task<T> InvokeAsync<T>(
            bool firstAsTarget,
            object target,
            params object[] parameters
        )
        {
            return Process.InvokeAsync<T>(firstAsTarget, target, parameters);
        }
    }
}
