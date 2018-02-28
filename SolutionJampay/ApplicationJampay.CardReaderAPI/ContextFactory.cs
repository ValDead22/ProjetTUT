using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.CardReaderAPI
{
    public class ContextFactory : IContextFactory
    {
        private static readonly Lazy<IContextFactory> _instance = new Lazy<IContextFactory>(() => new ContextFactory());

        /// <summary>
        /// Default factory instance.
        /// </summary>
        public static IContextFactory Instance => _instance.Value;

        /// <summary>
        /// Create and establish a new smart card context.
        /// </summary>
        /// <param name="scope">Scope of the establishment. This can either be a local or remote connection.</param>
        /// <returns>A new established smart card context</returns>
        public ISCardContext Establish(SCardScope scope)
        {
            var context = new SCardContext();
            context.Establish(scope);
            return context;
        }
    }
}
