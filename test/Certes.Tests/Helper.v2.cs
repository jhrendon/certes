﻿using System;
using System.Net.Http;
using Certes.Acme;
using Certes.Acme.Resource;
using Directory = Certes.Acme.Resource.Directory;

namespace Certes
{
    public static partial class Helper
    {
        public static readonly Directory MockDirectoryV2 = new Directory(
            new Uri("http://acme.d/newNonce"),
            new Uri("http://acme.d/newAccount"),
            new Uri("http://acme.d/newOrder"),
            new Uri("http://acme.d/revokeCert"),
            new Uri("http://acme.d/keyChange"),
            new DirectoryMeta(new Uri("http://acme.d/tos"), null, null, false));

        public static IKey GetKeyV2(KeyAlgorithm algo = KeyAlgorithm.ES256)
        {
            return KeyFactory.FromPem(algo.GetTestKey());
        }

        public static IAcmeHttpClient CreateHttp(Uri dirUri, HttpClient http)
            => new AcmeHttpClient(dirUri, http);

#if NETCOREAPP2_0 || NETCOREAPP1_0
        public static Func<Uri, IKey, IAcmeContext> ContextFactory
        {
            get => Cli.ContextFactory.Create;
            set => Cli.ContextFactory.Create = value;
        }

        public static Func<Uri, IAcmeClient> ClientFactory
        {
            get => Cli.ContextFactory.CreateClient;
            set => Cli.ContextFactory.CreateClient = value;
        }
#endif
    }
}
