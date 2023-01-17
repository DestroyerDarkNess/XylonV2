
Namespace Engine.PE

    Public Class AVEnums


#Region " Enum "

        Public Enum InjectorEntry
            LoadLibrary
            GetProcAddress
            GetModuleHandle
            CreateRemoteThread
            CreateThread
            FreeLibrary
        End Enum

        Public Enum HackEntry
            WriteProcessMemory
            ReadProcessMemory
            GetAsyncKeyState
            OpenProcess
            LoadLibrary
            VirtualAllocEx
            VirtualFreeEx
        End Enum

        Public Enum HackString
            aimbot
            esp
            crosshair
            noflash
            spread
            fov
            distance
            silent
            smooth
            wallhack
            hack
            opengl32
            cheat
            game
            invisible
            skin
            afk
            Weapon
            glow
            recoil
            fly
            speed
        End Enum

        Public Enum MaliciusString
            Themida
            Eh_Fram
            Aimbot
            Hack
            Wallhack
            Triggerbot
            Cheat
            Memory
            WCESERVICE
            WCE_SERVICE
            kiwi
            mimilib
            Mimikatz
            privilege
            sekurlsa
            logonpasswords
            meterpreter
            spoofing
            keylogger
            powersploit
            passdumper
            creddumper
            credentialdumper
            XScanPF
            ysoserial
            Sploit
        End Enum

        Public Enum ShellStr
            WshShellClass
            IWshShell
            CreateShortcut
            SetShowCmd
            GetShowCmd
            piShowCmd
            IPersistFile
            IShellLink
            WshShell
        End Enum

        Public Enum BrowserStealer
            Gecko
            Recovery
            Mozilla
            Chromium
            Chrome
            Cookie
            FileZilla
            Password
            Steal
            Edge
            Nord
            Proton
            OpenVPN
            Outlook
            Yandex
            Orbitum
            Opera
            Amigo
            Torch
            Comodo
            CentBrowser
            uCozMedia
            Rockmelt
            Sleipnir
            SRWare
            Vivaldi
            Sputnik
            Maxthon
            AcWebBrowser
            EpicBrowser
            MapleStudio
            BlackHawk
            Flock
            CoolNovo
            Baidu
            Titan
            Google
            browser
        End Enum

        Public Enum WalletStealer
            Armory
            AtomicWallet
            Bitcoin
            Bytecoin
            Dash
            Electrum
            Ethereum
            Exodus
            Jaxx
            Litecoin
            Monero
            StartWallets
            Zcash
        End Enum

        Public Enum GenericString
            Proxy
            Startup
            autorun
            Fuck
            Vir
            Ramsom
            ARP
            Crack
            Hack
            Memory
            CodeDom
            ProcMem
            Process
            Fake
            Checker
            Spoof
            UploadAsync
            UploadFileAsync
            UploadFileCompleted
            GetHostName
            HttpWebResponse
            Upload
            Guard
            Dump
        End Enum

        Public Enum SystemExeString
            mshta
            cmd
            svchost
            cscript
            regsvr32
            rundll32
            wscript
            rexec
            schtasks
            PowerShell
            '   exec
        End Enum

        Public Enum NetImportsString
            Reflection
            Management
            CodeDom
            dnlib
            Cryptography
        End Enum

        Public Enum NetPackerString
            Mpress
            Guard
            Confused
            Stub
            Dnlib
            Builder
            Obfuzcator
            Morphic
            Compiler
            Junk
            confusedbyattribute
        End Enum

        Public Enum CriptoString
            Xore
            Poly
            morphic
            Stairs
            RC4
            MD5
            Hash
            RC2
            Cesar
            Hex
            Shad
            blowfish
            AES
            pool
            Rinjandel
        End Enum

#End Region

    End Class

End Namespace

