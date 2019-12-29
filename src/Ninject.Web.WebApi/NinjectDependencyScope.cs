// -------------------------------------------------------------------------------------------------
// <copyright file="NinjectDependencyScope.cs" company="Ninject Project Contributors">
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

namespace Ninject.Web.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    using Ninject.Activation.Blocks;
    using Ninject.Infrastructure.Disposal;
    using Ninject.Parameters;

    /// <summary>
    /// Dependency Scope implementation for ninject
    /// </summary>
    public class NinjectDependencyScope : DisposableObject, IDependencyScope
    {
        private readonly IActivationBlock activationBlock;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyScope"/> class.
        /// </summary>
        /// <param name="activationBlock">The activation block.</param>
        public NinjectDependencyScope(IActivationBlock activationBlock)
        {
            this.activationBlock = activationBlock;
        }

        /// <summary>
        /// Gets the service of the specified type.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns>The service instance or <see langword="null"/> if none is configured.</returns>
        public object GetService(Type serviceType)
        {
            var request = this.activationBlock.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return this.activationBlock.Resolve(request).SingleOrDefault();
        }

        /// <summary>
        /// Gets the services of the specifies type.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns>All service instances or an empty enumerable if none is configured.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.activationBlock.GetAll(serviceType).ToList();
        }

        /// <summary>
        /// Releases resources held by the object.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> if called manually, otherwise by GC.</param>
        public override void Dispose(bool disposing)
        {
            this.activationBlock.Dispose();
            base.Dispose(disposing);
        }
    }
}