﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AjTalk.Language;

namespace AjTalk.Hosting
{
    public class RemotingHostClient : IHost
    {
        private IHost host;
        private string address;

        public RemotingHostClient(string address)
        {
            this.address = address;
            this.host = (IHost)Activator.GetObject(typeof(IHost), address);

            if (Machine.Current != null)
                Machine.Current.RegisterHost(this);
        }

        public RemotingHostClient(string hostname, int port, string name)
            : this(MakeAddress(hostname, port, name))
        {
        }

        public Guid Id
        {
            get { return this.host.Id; }
        }

        public string Address { get { return this.address; } }

        public bool IsLocal { get { return false; } }

        public void Execute(string commandtext)
        {
            this.host.Execute(commandtext);
        }

        public object Evaluate(string expression)
        {
            return this.ClientMarshalling(this.host.Evaluate(expression));
        }

        public object Invoke(IObject obj, string msgname, params object[] arguments)
        {
            return this.ClientMarshalling(this.host.Invoke(obj, msgname, arguments));
        }

        public object ResultToObject(object result)
        {
            throw new NotImplementedException();
        }

        private object ClientMarshalling(object result)
        {
            if (result == null)
                return null;

            if (!(result is IObject))
                return result;

            if (result is ObjectProxy)
                return result;

            if (!System.Runtime.Remoting.RemotingServices.IsTransparentProxy(result))
                return result;

            return new ClientObject(this.host, (IObject)result);
        }

        internal static string MakeAddress(string hostname, int port, string name)
        {
            return string.Format("tcp://{0}:{1}/{2}", hostname, port, name);
        }
    }
}