namespace Myproject.EventBus.Messages
{
	public class FieldCreateMessage : Message
	{
		// Bonus!
		// Incapsulate public fields where is needed with properties/methods 
		private bool[,] _field;

		public bool[,] Field
		{
			get => _field;
			private set => _field = value;
		}

		public FieldCreateMessage(bool[,] field)
		{
			Field = field;
		}
	}
}