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
using System.ComponentModel.Composition;
using System.Linq;
using dnSpy.Text.MEF;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;

namespace dnSpy.Text.Editor {
	[Export(typeof(IWpfTextViewCreationListener))]
	sealed class MouseWpfTextViewCreationListener : IWpfTextViewCreationListener {
		readonly IEditorOperationsFactoryService editorOperationsFactoryService;
		readonly Lazy<IMouseProcessorProvider, IOrderableContentTypeAndTextViewRoleMetadata>[] mouseProcessorProviders;

		[ImportingConstructor]
		MouseWpfTextViewCreationListener(IEditorOperationsFactoryService editorOperationsFactoryService, [ImportMany] IEnumerable<Lazy<IMouseProcessorProvider, IOrderableContentTypeAndTextViewRoleMetadata>> mouseProcessorProviders) {
			this.editorOperationsFactoryService = editorOperationsFactoryService;
			this.mouseProcessorProviders = Orderer.Order(mouseProcessorProviders).ToArray();
		}

		public void TextViewCreated(IWpfTextView textView) {
			if (!textView.Roles.Contains(PredefinedTextViewRoles.Interactive))
				return;

			new TextViewMouseProcessorCollection(textView, mouseProcessorProviders, editorOperationsFactoryService);
		}
	}
}
