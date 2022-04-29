using KingAOP.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net
{
    [Serializable]
    
    public class LogAspect: OnMethodBoundaryAspect
    {
        
        private LoggerService loggerService;
        public LogAspect()
        {
            //loggerService = (LoggerService)Activator.CreateInstance(loggerType);
            loggerService = new FileLogger();
        }
       
        public override void OnEntry(MethodExecutionArgs args)
        {
            var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
            {
                Name = t.Name,
                Type = t.ParameterType.Name,
                Value = args.Arguments
            }).ToList();
            var logDetail = new LogDetail
            {
                FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                MethodName = args.Method.Name,
                Parameters = logParameters

            };
            loggerService.Info(logDetail);
        }
    }
}
