using Avalonia.Labs.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperX.UI.Controls.Avalonia;

public class AsyncImage : global::Avalonia.Labs.Controls.AsyncImage
{
    protected override Type StyleKeyOverride => typeof(global::Avalonia.Labs.Controls.AsyncImage);
}
