using System;

namespace AjTalk
{
	public interface IObject
	{
		IClass Class { get; }
		object this[int n] { get; set;}
		object SendMessage(string msgname, object [] args);
	}
}
