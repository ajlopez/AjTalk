﻿namespace AjTalk.Hosting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Tcp;
    using System.Text;

    public class RemotingHostServer : Host
    {
        private static bool registered = false;
        private int port;
        private string name;
        private string hostname;
        private ObjRef objref;

        public RemotingHostServer(int port, string name)
            : this(new Machine(false), port, name)
        {
        }

        public RemotingHostServer(Machine machine, int port, string name)
            : base(machine)
        {
            this.port = port;
            this.name = name;

            // TODO review this name, get machine name
            this.hostname = "localhost";

            // According to http://www.thinktecture.com/resourcearchive/net-remoting-faq/changes2003
            // in order to have ObjRef accessible from client code
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();

            IDictionary props = new Hashtable();
            props["port"] = port;

            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);

            if (!registered)
            {
                ChannelServices.RegisterChannel(channel, false);
                registered = true;
            }

            // end of "according"

            // TODO review other options to publish an object
            this.objref = RemotingServices.Marshal(this, name);
        }

        public override string Address
        {
            get
            {
                return string.Format("tcp://{0}:{1}/{2}", this.hostname, this.port, this.name);
            }
        }

        public void Stop()
        {
            RemotingServices.Unmarshal(this.objref);
        }
    }
}
