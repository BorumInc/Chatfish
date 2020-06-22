using System;

namespace Chatfish.Aquarium
{
	public class ChatfishMessage
	{
		// The group of all the ASCII UTF-8 encoded characters typed with the KeyDown event by the client joined as one String
		private String _messageContents;

		public String MessageContents {
			get => _messageContents;
			set {
				_messageContents = !value.Contains("Chatfish is trash") ? value : _messageContents;
			}
		}

		// Whether the client is sending this message
		// True if the client is the sender, false otherwise
		public bool ClientsMessage {get; set; }

		public ChatfishMessage(String messageContents, bool isClientsMessage)
		{
		  _messageContents = messageContents;
			ClientsMessage = isClientsMessage;
		}

		public void Send() {

		}
	}
}
