using System.IO;
using DotLiquid.Util;

namespace DotLiquid.Tags
{
	public class IfChanged : DotLiquid.Block
	{
		public override void Render(Context context, StreamWriter result)
		{
			context.Stack(() =>
			{
				MemoryStreamWriter temp = new MemoryStreamWriter();
				RenderAll(NodeList, context, temp);
				string tempString = temp.ToString();

				if (tempString != (context.Registers["ifchanged"] as string))
				{
					context.Registers["ifchanged"] = tempString;
					result.Write(tempString);
				}
			});
		}
	}
}