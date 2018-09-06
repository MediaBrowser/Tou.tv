using System;
using System.Collections.Generic;
using MediaBrowser.Channels.TouTv.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using System.IO;
using MediaBrowser.Model.Drawing;

namespace MediaBrowser.Channels.TouTv
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages, IHasThumbImage
    {
        internal static string ChannelName = "ICI Tou.tv";

        internal static string ChannelDescription =
            "ICI Tou.tv est une webtélé de divertissement proposant une expérience de vidéo sur demande offerte par Radio-Canada.";

        internal static Plugin Instance { get; private set; }

        public override string Name
        {
            get { return ChannelName; }
        }

        private Guid _id = new Guid("3ed7785b-c408-43b0-8fb0-76293ed0607d");
        public override Guid Id
        {
            get { return _id; }
        }

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = "toutv",
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.configPage.html"
                }
            };
        }

        public Stream GetThumbImage()
        {
            var type = GetType();
            return type.Assembly.GetManifestResourceStream(type.Namespace + ".thumb.png");
        }

        public ImageFormat ThumbImageFormat
        {
            get
            {
                return ImageFormat.Png;
            }
        }

        public override string Description
        {
            get { return ChannelDescription; }
        }

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }
    }
}
