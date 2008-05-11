using System;

namespace AjTalk
{
	/// <summary>
	/// Summary description for IMessage.
	/// </summary>
	public interface IMessage
	{
		string Name { get; }
		int Arity { get; }
	}
}
