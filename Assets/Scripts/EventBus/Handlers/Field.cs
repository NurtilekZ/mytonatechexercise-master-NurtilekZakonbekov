using Myproject.EventBus.Messages;

namespace Myproject.EventBus.Handlers
{
	public class Field : Handler<FieldCreateMessage>
	{
		private int Size = 12;

		public override void HandleMessage(FieldCreateMessage message)
		{
			var childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(message.Field[i / Size, i % Size]);
			}
		}
	}
}