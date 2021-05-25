using System;

namespace LL.Views
{
	internal interface ICloseable
	{
		event EventHandler CloseRequest;
	}
}