using System;

namespace AjTalk
{
	public interface IMethod
	{
		string Name { get; }
        IClass Class { get; }
		object Execute(IObject receiver, object [] args);		
	}
}
