﻿namespace Exemplum.Infrastructure.Caching
{
    using Application.Common.Caching;
    using System;
    using System.Collections.Generic;

    public class CacheOptions
    {
        /// <summary>
        /// If the caching operation throws and exception dont throw it and just let caching silently fail. 
        /// </summary>
        public bool HideErrors { get; set; }

        /// <summary>
        /// Top level prefix for all caching keysL
        /// </summary>
        public string KeyPrefix { get; set; } = "AppCache";

        /// <summary>
        /// The default options when caching any value if no options are provided or there is no CacheConfigurators for the CacheItem type this will be used
        /// </summary>
        public CacheEntryOptions GlobalCacheEntryOptions { get; set; } = new CacheEntryOptions();

        /// <summary>
        /// A list of configuration entry options for CacheItem types if no options are provided when an item is cache we will check for a configurator
        /// for the CacheItem type here 
        /// </summary>
        public List<Func<Type, CacheEntryOptions?>> CacheConfigurators { get; set; } = new List<Func<Type, CacheEntryOptions?>>();
    }
}