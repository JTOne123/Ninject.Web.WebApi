﻿// -------------------------------------------------------------------------------------------------
// <copyright file="WebApiWebHostModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2007-2010 Enkari, Ltd. All rights reserved.
//   Copyright (c) 2010-2017 Ninject Project Contributors. All rights reserved.
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   You may not use this file except in compliance with one of the Licenses.
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
// -------------------------------------------------------------------------------------------------

namespace Ninject.Web.WebApi.WebHost
{
    using System;
    using System.Web.Http;

    using Ninject.Modules;
    using Ninject.Web.Common;

    /// <summary>
    /// Defines the bindings of the WebApi WebHost extension.
    /// </summary>
    public class WebApiWebHostModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<HttpConfiguration>().ToMethod(ctx => GlobalConfiguration.Configuration);
            this.Kernel.Components.Add<INinjectHttpApplicationPlugin, NinjectWebApiWebHostHttpApplicationPlugin>();
        }

        /// <summary>
        /// Called after loading the modules. A module can verify here if all other required modules are loaded.
        /// </summary>
        public override void VerifyRequiredModulesAreLoaded()
        {
            if (!this.Kernel.HasModule(typeof(WebApiModule).FullName))
            {
                throw new InvalidOperationException("This module requires Ninject.Web.WebAPI extension");
            }
        }
    }
}