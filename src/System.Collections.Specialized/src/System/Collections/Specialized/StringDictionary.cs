// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace System.Collections.Specialized
{
    /// <devdoc>
    ///    <para>Implements a hashtable with the key strongly typed to be
    ///       a string rather than an object. </para>
    ///    <para>Consider this class obsolete - use Dictionary&lt;String, String&gt; instead
    ///       with a proper StringComparer instance.</para>
    /// </devdoc>
    public class StringDictionary : IEnumerable
    {
        // For compatibility, we want the Keys property to return values in lower-case.
        // That means using ToLower in each property on this type.  Also for backwards
        // compatibility, we will be converting strings to lower-case, which has a 
        // problem for some Georgian alphabets.  
        private readonly Hashtable _contents = new Hashtable();


        /// <devdoc>
        /// <para>Initializes a new instance of the StringDictionary class.</para>
        /// <para>If you're using file names, registry keys, etc, you want to use
        /// a Dictionary&lt;String, Object&gt; and use 
        /// StringComparer.OrdinalIgnoreCase.</para>
        /// </devdoc>
        public StringDictionary()
        {
        }

        /// <devdoc>
        /// <para>Gets the number of key-and-value pairs in the StringDictionary.</para>
        /// </devdoc>
        public virtual int Count
        {
            get
            {
                return _contents.Count;
            }
        }


        /// <devdoc>
        /// <para>Indicates whether access to the StringDictionary is synchronized (thread-safe). This property is 
        ///    read-only.</para>
        /// </devdoc>
        public virtual bool IsSynchronized
        {
            get
            {
                return _contents.IsSynchronized;
            }
        }

        /// <devdoc>
        ///    <para>Gets or sets the value associated with the specified key.</para>
        /// </devdoc>
        public virtual string this[string key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }

                return (string)_contents[key.ToLowerInvariant()];
            }
            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }

                _contents[key.ToLowerInvariant()] = value;
            }
        }

        /// <devdoc>
        /// <para>Gets a collection of keys in the StringDictionary.</para>
        /// </devdoc>
        public virtual ICollection Keys
        {
            get
            {
                return _contents.Keys;
            }
        }


        /// <devdoc>
        /// <para>Gets an object that can be used to synchronize access to the StringDictionary.</para>
        /// </devdoc>
        public virtual object SyncRoot
        {
            get
            {
                return _contents.SyncRoot;
            }
        }

        /// <devdoc>
        /// <para>Gets a collection of values in the StringDictionary.</para>
        /// </devdoc>
        public virtual ICollection Values
        {
            get
            {
                return _contents.Values;
            }
        }

        /// <devdoc>
        /// <para>Adds an entry with the specified key and value into the StringDictionary.</para>
        /// </devdoc>
        public virtual void Add(string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            _contents.Add(key.ToLowerInvariant(), value);
        }

        /// <devdoc>
        /// <para>Removes all entries from the StringDictionary.</para>
        /// </devdoc>
        public virtual void Clear()
        {
            _contents.Clear();
        }

        /// <devdoc>
        ///    <para>Determines if the string dictionary contains a specific key</para>
        /// </devdoc>
        public virtual bool ContainsKey(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            return _contents.ContainsKey(key.ToLowerInvariant());
        }

        /// <devdoc>
        /// <para>Determines if the StringDictionary contains a specific value.</para>
        /// </devdoc>
        public virtual bool ContainsValue(string value)
        {
            return _contents.ContainsValue(value);
        }

        /// <devdoc>
        /// <para>Copies the string dictionary values to a one-dimensional <see cref='System.Array'/> instance at the 
        ///    specified index.</para>
        /// </devdoc>
        public virtual void CopyTo(Array array, int index)
        {
            _contents.CopyTo(array, index);
        }

        /// <devdoc>
        ///    <para>Returns an enumerator that can iterate through the string dictionary.</para>
        /// </devdoc>
        public virtual IEnumerator GetEnumerator()
        {
            return _contents.GetEnumerator();
        }

        /// <devdoc>
        ///    <para>Removes the entry with the specified key from the string dictionary.</para>
        /// </devdoc>
        public virtual void Remove(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            _contents.Remove(key.ToLowerInvariant());
        }
    }
}
