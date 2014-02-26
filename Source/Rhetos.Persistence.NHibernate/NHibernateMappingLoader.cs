﻿/*
    Copyright (C) 2014 Omega software d.o.o.

    This file is part of Rhetos.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as
    published by the Free Software Foundation, either version 3 of the
    License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rhetos.Persistence.NHibernate
{
    public class NHibernateMappingLoader : INHibernateMapping
    {
        private readonly string _nHibernateMappingFile;

        public NHibernateMappingLoader(string nHibernateMappingFile)
        {
                _nHibernateMappingFile = nHibernateMappingFile;
        }

        private static string _mapping;
        private static readonly object _mappingLock = new object();

        public string GetMapping()
        {
            lock (_mappingLock)
            {
                if (_mapping == null)
                    _mapping = File.ReadAllText(_nHibernateMappingFile, Encoding.Default);
            }
            return _mapping;
        }
    }
}
