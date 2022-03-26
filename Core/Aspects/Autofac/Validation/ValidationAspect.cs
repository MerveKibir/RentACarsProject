using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //_validaterType EntityNesnesidir. O an hangi Entity ile çalışılıyorsa onun validatoru dur Örn: CarValidator
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //Base Type AbstractValidaterder. <> içerisindeki entity tipini  alır. 1 tane olduğundan 0 yazıldı(indis)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //tip kontrolü yapılarak ilgili tipteki entity alınıyor
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}