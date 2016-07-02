﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using dnSpy.Contracts.Menus;
using dnSpy.Contracts.Text.Editor;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;

namespace dnSpy.Text.Editor {
	sealed class DnSpyTextEditorOptions {
		public Guid? MenuGuid { get; }
		public IContentType ContentType { get; }
		public string ContentTypeString { get; }
		public Func<GuidObjectsCreatorArgs, IEnumerable<GuidObject>> CreateGuidObjects { get; }
		public ITextBuffer TextBuffer { get; }
		public Func<IGuidObjectsCreator> CreateGuidObjectsCreator { get; }

		public DnSpyTextEditorOptions(CommonTextEditorOptions options, ITextBuffer textBuffer, Func<IGuidObjectsCreator> createGuidObjectsCreator) {
			MenuGuid = options.MenuGuid;
			ContentType = options.ContentType;
			ContentTypeString = options.ContentTypeString;
			CreateGuidObjects = options.CreateGuidObjects;
			TextBuffer = textBuffer;
			CreateGuidObjectsCreator = createGuidObjectsCreator;
		}
	}
}
