namespace friendly_remindersWinUI
{
    public static class GLOBALS
    {
        public static int remindMode { get; set; }
        public static int minRemind { get; set; }
        public static bool hornyMode { get; set; }
        public static bool sleepMode { get; set; }

        // Developer toggles.
        public static bool intDev_feature_devControlsPage { get; set; } // Developer controls page.
        public static bool intDev_mode_insMode { get; set; } // Insane Mode.
        public static bool intDev_feature_debugForceTime { get; set; } // Force 30s time. (overrides minRemind)

        // Secrets
        public static string intDev_page_hiddenMsgCode { get; set; }
        public static bool intDev_feature_hiddenMsgPage { get; set; }   

        // Program Variables
        public static string programBranch { get; set; }
        
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        // Arrays
        public static string[] altReminderArr = new string[17]
        {
                "i hope bby is alright <3", // 1
                "mmwah <333333", // 2
                "so much mwah mwahs for my baby <333", // 3
                "mwah ily <3", // 4
                "weewoo", // 5
                "ur such a good boy <3", // 6
                "ur my good boy hehe <3", // 7
                "lovely cutie <33", // 8
                "i love you my good boy <3", // 9
                "ilysm baby <3", // 10
                "i love youuuuu <33333", // 11
                "bby cocker", // 12
                "bby boner :o", // 13
                "lovely so cute howwwwww >:(", // 14
                "i love you lovely <3", // 15
                "ilysm lovely <3", // 16
                "i love you so much my bby <3" // 17
        };
        public static string[] reminderArr = new string[40]
        {
            "boop lovely <3", // 1
            "ilysm bby <3333", // 2
            "You're so cute. <3", // 3
            "*mwah* kisses for bby <3", // 4
            "imma smother you in huggies ^^", // 5
            "i love you bby <3", // 6
            "cmere bby, mwah! <3", // 7
            "awe look at my adorable baby hehe <3", // 8
            "camiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii", // 9
            "cute people use my program, that's you :)", // 10
            "i'll always be there for you my lovely <3", // 11
            "fumofumo hehe :>", // 12
            "my baby so cute omg :o", // 13
            "you're such a good girl awe <3", // 14
            "i love you so much cutie <3", // 15
            "you're so adorable aweeeee <3", // 16
            "Is it seokjin saturday yet?", // 17
            "my bby will always be special to me ^^", // 18
            "Maybe bby needs some huggies :)", // 19
            "weewoo my baby cute :o", // 20
            // "gn bby <3" (Possible timed ?)
            "ily cutie <3", // 21
            "i love you cutie <3", // 22
            "i love you so much my baby <3", // 23
            "i love you my good girl <3", // 24
            "bby cocker mmmmm :horny:", // 25
            "Friendly reminder to suck my cocker pls. thx <3", // 26
            "'bby boner' shut.", // 27
            "All I think about is your adorable face, I never think of anything else hehe. <3", // 28
            "boop ^^", // 29
            "ahehehe cutie <3", // 30
            "should see this source code jeez haha :o", // 31
            "so many quotes for my baby :o", // 32
            "I would die for you my lovely baby <333", // 33
            "I always imagine you right beside me ^^", // 34
            "Reminder to kiss me irl. thx <3", // 35
            "huggies from mommy? :o", // 36
            "ur so fkin sexc omg :horny:", // 37
            "Can we perhaps makeout lovely? :o", // 38
            "weewoo", // 39
            "How bby so cute? Howwwww >:(" // 40
        };
        public static string[] hornyReminderArr = new string[17]
        {
            "can i suck ur cocker pls ^^", // 1
            "baby so sexc, I want to makeout with her :o", // 2
            "can we cuddle perhaps :>", // 3
            "boop <3", // 4
            "imma choke my baby </3", // 5
            "baby can you suck my cocker pls :o", // 6
            "baby's cocker mmmmm", // 7
            "my cocker in baby's mouf :o", // 8
            "*bonk* horny.", // 9
            "bby so horny omg", // 10
            "bby so sexc", // 11
            "wanna makeout baby? :o", // 12
            "perhaps baby should try my cocker sometime ^^", // 13
            "kissing bby while making out ^^", // 14
            "baby baby weewoo", // 15
            "baby v horny :o", // 16
            "Reminder to suck my cocker sometime. ^^" // 17
        };
    }
}
