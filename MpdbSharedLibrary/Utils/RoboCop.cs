using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Utils
{
    /// <summary>
    /// YoUR MOVe cReEP
    /// </summary>
    public class RoboCop
    {
        private string[] _Bootup = {
                                               "COMMAND.COM",
                                               "LOAD BIOS",
                                               "BIOS SYSTEM CHECK",
                                               "RAM CHECK",
                                               "CONFIG.SYS",
                                               "BIO.COM INTERFACE",
                                               "TO ROM I/O",
                                               "CONTROLLER",
                                               "COMSPEC.EXE",
                                               "MEMORY.DAT",
                                               "ROBO UTILS",
                                               "SYSTEM BUFFER",
                                               "PARAMETERS",
                                               "PARITY SET",
                                               "MEMORY SET",
                                               "SYSTEM STATUS",
                                               "OK"
                                          };
        private string[] _PrimeDirectives ={
                                               "1. SERVE THE PUBLIC TRUST",
                                               "2. PROTECT THE INNOCENT",
                                               "3. UPHOLD THE LAW",
                                               "4. [CLASSIFIED]"
                                           };

        private string[] _Quotes ={
                                    "Well give the man a hand!",
                                    "Can you fly, Bobby?",
                                    "I'd buy that for a dollar",
                                    "You know, he's a sweet old man.",
                                    "Pretty simple math, huh, Bob?",
                                    "You better pray that that unholy monster of yours doesn't screw up. ",
                                    "They'll fix you. They fix everything.",
                                    "Looking for me?",
                                    "I know you! You're dead! We killed you!",
                                    "You better watch your back, Bob.",
                                    "Jones is gonna come looking for you.",
                                    "Too bad about Kinney, huh?",
                                    "He fumbled the ball, I was there to pick it up.",
                                    "Soon as some poor schmuck volunteers.",
                                    "Excuse me, I have to go. Somewhere there is a crime happening.",
                                    "Let me make something clear to you. He doesn't have a name. He has a program. He's product.",
                                    "Bitches, leave!",
                                    "See, I got this problem. Cops don't like me. So I don't like cops.",
                                    "Okay Miller! Don't hurt the mayor! We'll give you what you want!",
                                    "Nobody ever takes me seriously! We'll get serious now... and kiss the mayor's ass goodbye!",
                                    "Nice shooting, son. What's your name?",
                                    "Forget it, kid. This guy's a serious asshole.",
                                    "Your client's a scumbag, you're a scumbag, and scumbags see the judge on Monday morning. Now get out of my office, and take laughing boy with you!",
                                    "Murphy, it's you!",
                                    "Please put down your weapon. You have 20 seconds to comply.",
                                    "Four... three... two... one... I am now authorized to use physical force!",
                                    "Thank you for your cooperation. Good night.",
                                    "Book him! What's the charge? He's a cop killer.",
                                    "Dick, you're *fired*!",
                                    "Well guys, the other one was upstairs. She was sweeeeet, mmph-mmm-mmm. I took her out, Ha-ha-ha-ha-ha-ha...",
                                    "You probably don't think I'm a very nice guy... do ya? ",
                                    "I had a guaranteed military sale with ED209! Renovation program! Spare parts for 25 years! Who cares if it worked or not!",
                                    "First, don't mess with me. I'm a desperate man! And second, I want some fresh coffee. And third, I want a recount! And no matter how it turns out, I want my old job back!",
                                    "I'm cashing you out, Bob.",
                                    "Oooh. Guns, guns, guns. C'mon, Sal. The Tigers are playing...",
                                    "Frankie, blow this cocksucker's head off.",
                                    "You call this a GLITCH?",
                                    "I work for Dick Jones! Dick Jones! He's the Number Two Guy at OCP. OCP runs the cops.",
                                    "Don't mess with Jones, man. He'll make sushi out of you.",
                                    "Good night, sweet prince.",
                                    "Nukem. Get them before they get you. Another quality home game from Butler Brothers.",
                                    "Old Detroit has a cancer. That cancer is crime.",
                                    "What? I thought we agreed on total body prosthesis, now lose the arm okay!",
                                    "Shut him down, prep him for surgery.",
                                    "Hey, he's old, we're young, and that's life.",
                                    "Hey, dickey boy, how's tricks? ",
                                    "That's two million workers living in trailers, that means drugs, gambling, prostitution... ",
                                    "We practically are the military.",
                                    "Here at Security Concepts, we're predicting the end of crime in Old Detroit within 40 days. There's a new guy in town. His name is RoboCop.",
                                    "Does it hurt? Does it hurt?",
                                    "Are you a college boy?",
                                    "The Star Wars Space Peace Platform",
                                    "That's life in the big city",
                                    "Hey there buddy boy",
                                    "Good business is where you find it",
                                    "Oh Dick, I'm very disappointed",
                                    "Stay out of trouble",
                                    "Your move creep",
                                    "Dead or alive, you're coming with me",
                                    "And remember, we care",
                                    "Madame, you have suffered an emotional shock. I will notify a rape crisis center.",
                                    "You mind if I, zip this up?",
                                    "Something with reclining leather seats, that goes really fast and gets really shitty gas mileage!"
                                 };
        /// <summary>
        /// You're gonna be a bad motherfucker
        /// </summary>
        public IEnumerable<string> Bootup { get { return _Bootup; } }
        /// <summary>
        /// cAn YOu FLy BobBY
        /// </summary>
        public IEnumerable<string> PrimeDirectives { get { return _PrimeDirectives; } }
        /// <summary>
        /// I fucking love this guy
        /// </summary>
        public IEnumerable<string> Quotes { get { return _Quotes; } }
    }
}
