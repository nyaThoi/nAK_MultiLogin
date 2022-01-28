using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace nAK_MC
{
    public class Config
    {
        public class MCUser
        {
            public MCUser()
            {
                this.Username = string.Empty;
                this.Password = string.Empty;
                this.Server = string.Empty;
                this.Path = string.Empty;
            }
            public MCUser(string name, string password, string sr, string gp)
            {
                Username = name;
                Password = password;
                Server = sr;
                Path = gp;
            }
            [XmlAttribute] public string Username { get; set; }
            [XmlAttribute] public string Password { get; set; }
            [XmlAttribute] public string Server { get; set; }
            [XmlAttribute] public string Path { get; set; }

        }

        public static List<MCUser> mCUsers = new List<MCUser>();
        static MCUser[] _readXML(string fileName = @"config.xml")
        {
            var xs = new XmlSerializer(typeof(MCUser[]));
            var xr = XmlReader.Create(fileName);
            try
            {
                return xs.Deserialize(xr) as MCUser[];
            }
            finally
            {
                xr.Close();
            }

        }
        static void _saveXML(MCUser[] users, string fileName = @"config.xml")
        {            
            var xs = new XmlSerializer(typeof(MCUser[]));
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };
            var xw = XmlWriter.Create(fileName, settings);

            try
            {
                xs.Serialize(xw, users);
            }
            finally
            {
                xw.Close();
            }
        }
        public static void _load()
        {
            var list = new List<MCUser>();
            list.AddRange(_readXML());

            mCUsers.Clear();
            mCUsers.AddRange(list);
            //if (list.Count == 0)
            //    Console.WriteLine($"Somethings wrong on config.xml");

            //foreach (var item in mCUsers)
            //    Console.WriteLine($"{item.ID} - {item.Username} - {item.Password} - {item.Server}");
        }
        public static void _save()
        {
            _saveXML(mCUsers.ToArray());
        }
        public static void _AddItems(string user, string pw, string sr, string path)
        {
            Config.MCUser mc = new Config.MCUser();
            mc.Username = user;
            mc.Password = pw;
            mc.Server = sr;
            mc.Path = path;
            Config.mCUsers.Add(mc);
        }
        public static void _RemoveItems(string user, string pw, string sr, string path)
        {
            var itr = mCUsers.Single(r => r.Username == user);
            mCUsers.Remove(itr);
        }

    }
}
