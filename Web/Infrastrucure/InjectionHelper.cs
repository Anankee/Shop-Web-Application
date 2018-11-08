using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Infrastrucure
{
    public class InjectionHelper
    {
        public static T GetIncjection<T>()
        {
            return DependencyResolver.Current.GetService<T>();
        }
    }
}