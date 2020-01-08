//-------------------------------------------------------------------------------
// <copyright file="NinjectWebCommon.cs" company="Ninject Project Contributors">
//   Copyright (c) 2012 Ninject Project Contributors
//   Authors: Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SampleApplication.App_Start.NinjectWebCommon), "Start")]

namespace SampleApplication.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject.Web.Common.WebHost;

    /// <summary>
    /// Bootstrapper for the application.
    /// </summary>
    public static class NinjectWebCommon 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
        }
    }
}