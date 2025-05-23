﻿using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace CertGenerator
{
    class BaseOptions
    {
        [Option('v', "verbose", Required = false, HelpText = "Use verbose output")]
        public bool Verbose { get; set; }

        [Option("subject", Required = true, HelpText ="The subject of the certificate. For instance: \"CN=Test\"")]
        public string SubjectName { get; set; }


        [Option("out-pfx", Required = true)]
        public string PfxFile { get; set; }

        [Option("out-pass", Required = false)]
        public string PfxPassword { get; set; }

        [Option("export-key", Required = false, Default = false)]
        public bool ExportKey { get; set; }

        [Option("no-pem", Required = false, Default = false)]
        public bool NoPem { get; set; }
    }

    [Verb("generate-ca", HelpText = "Generate root authority")]
    class RootOptions : BaseOptions
    {
      
    }

    [Verb("generate-ica", HelpText = "Generate intermediate authority")]
    class IcaOptions : BaseOptions
    {
        [Option("in-pfx", Required = true)]
        public string InPfxFile { get; set; }

        [Option("in-pass", Required = false)]
        public string InPfxPassword { get; set; }        
    }

    [Verb("generate-self-signed", HelpText = "Generate self-signed certificate")]
    class SelfSignedOptions : BaseOptions
    {
        [Option("no-dns", Default = true, HelpText ="Do not add a dns name to the certificate")]
        public bool DoNotAddDns { get; set; }

        [Option("valid-days", Default = 365, HelpText = "How many days is this certificate valid?")]
        public int ValidDays { get; set; }

        [Option("not-before", Required = false, Default = "", HelpText = "Format: dd.MM.yyyy HH:mm")]
        public string NotBefore { get; set;}
    }

    [Verb("generate", HelpText = "Generate client certificate")]
    class Options : BaseOptions
    {     
        [Option("in-pfx", Required = true)]
        public string InPfxFile { get; set; }

        [Option("in-pass", Required = false)]
        public string InPfxPassword { get; set; }            
    }
}
