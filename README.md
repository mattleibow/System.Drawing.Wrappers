 System.Drawing.Wrappers
==============
This is a porting layer between System.Drawing.Graphics and 
- Android.Drawing.Canvas (on Android)
- Windows.UI.Xaml.* (on WinRT)

This layer allows to share the same primitive drawing code between the .NET and Android platforms.

  
 Usage
==============

	using (var g = new Graphics(canvas))
	using (var pen = new Pen(Colors.DarkBlue, 3))
	using (var brush = new SolidBrush(Colors.LightBlue))
	using (var text = new SolidBrush(Colors.Orange))
	using (var font = new Font(this.FontFamily, 12))
	{
		g.Clear(Colors.LemonChiffon);

		var rect = Shapes.CreateRectangle(100, 50, 150, 200);
		
		g.FillEllipse(brush, rect);
		g.DrawRectangle(pen, rect);

		g.DrawLine(pen, 
				   rect.Margin.Left, 
				   rect.Margin.Top,
				   rect.Margin.Left + rect.Width, 
				   rect.Margin.Top + rect.Height);

		g.DrawString("Hi", font, text, rect.CenterX(), rect.CenterY());
	}

  
 Author
==============

http://github.com/mattleibow
	
	
 License
==============

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

  http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

  
