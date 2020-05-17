using System;
using System.Collections.Generic;
using System.Linq;

namespace cs_blackjack
{
    class Program
    {
        public static void StartBlackJack()
        {
            var randomNumber = new Random();

            var suitOfCardList = new List<string>() { "Hearts", "Spades", "Diamonds", "Cubs" };
            var rankOfCardList = new List<string>() { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

            List<Card> deckOfCards = new List<Card> { };
            List<Card> dealerHand = new List<Card> { };
            List<Card> playerOneHand = new List<Card> { };
            List<Card> valueOfHandOne = new List<Card> { };

            //This is creating all the Objects in the class Card
            foreach (var selectedRankOfCard in rankOfCardList)
            {

                foreach (var selectedSuitOfCard in suitOfCardList)
                {
                    deckOfCards.Add(new Card
                    {
                        Rank = selectedRankOfCard,
                        Suit = selectedSuitOfCard,
                    });
                }
            }

            // This is randomizing the cards
            for (var firstIndex = deckOfCards.Count() - 1; firstIndex >= 1; firstIndex--)
            {
                {
                    int secondIndex = randomNumber.Next(0, firstIndex);

                    var firstValue = deckOfCards[firstIndex];

                    deckOfCards[firstIndex] = deckOfCards[secondIndex];

                    deckOfCards[secondIndex] = firstValue;
                }
            }

            Console.Write("Would you like to Start a game of BlackJack (Yes or No)?");
            var startGame = Console.ReadLine();
            if (startGame == "No" || startGame == "no")
            {
                Console.WriteLine($"Ok, too bad, Come play next time");
            }
            if (startGame == "Yes" || startGame == "yes")
            {
                Console.WriteLine("Welcome to the game of BlackJack. What is your name?");
                var playerOne = Console.ReadLine();
                Console.WriteLine($"Nice to meet you {playerOne}, Welcome to the wonderful world of Gambling! Let get started. The Dealer will get Their two cards first.");

                dealerHand.Add(deckOfCards[0]);
                dealerHand.Add(deckOfCards[1]);
                deckOfCards.Remove(deckOfCards[0]);
                deckOfCards.Remove(deckOfCards[1]);

                Console.Write($"Now it is time to get your cards. Would you like to get your cards (Type Yes)?");
                var getCards = Console.ReadLine();
                if (getCards == "Yes" || getCards == "yes")
                {
                    playerOneHand.Add(deckOfCards[0]);
                    playerOneHand.Add(deckOfCards[1]);
                    int currentValueOfHand = playerOneHand[0].TheValue() + playerOneHand[1].TheValue();
                    Console.WriteLine(deckOfCards[0].RankAndSuit());
                    Console.WriteLine(deckOfCards[1].RankAndSuit());
                    deckOfCards.Remove(deckOfCards[0]);
                    deckOfCards.Remove(deckOfCards[1]);
                    Console.WriteLine($" The Value of your two cards is {currentValueOfHand}. Would you like to take a hit (Yes or No)?");
                    var takeHit = Console.ReadLine();
                    if (takeHit == "No" || takeHit == "no")
                    {
                        Console.WriteLine($" Ok, now let's see the dealer's hand. The dealer has {dealerHand[0].RankAndSuit()} and {dealerHand[1].RankAndSuit()}");
                        int dealerHandAfterShowing = dealerHand[0].TheValue() + dealerHand[1].TheValue();
                        if (dealerHandAfterShowing >= 17)
                        {
                            if (currentValueOfHand < dealerHandAfterShowing)
                            {
                                Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {dealerHandAfterShowing}. Would you like to play again (Yes or No)?");
                                var playAgain = Console.ReadLine();
                                if (playAgain == "yes" || playAgain == "Yes")
                                {
                                    StartBlackJack();
                                }
                                if (playAgain == "No" || playAgain == "no")
                                {
                                    Console.WriteLine($"Thank you for playing. Come back soon");
                                }
                            }
                            if (currentValueOfHand > dealerHandAfterShowing)
                            {
                                Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                var playAgain = Console.ReadLine();
                                if (playAgain == "yes" || playAgain == "Yes")
                                {
                                    StartBlackJack();
                                }
                                if (playAgain == "No" || playAgain == "no")
                                {
                                    Console.WriteLine($"Thank you for playing. Come back soon");
                                }
                            }
                        }
                        if (dealerHandAfterShowing < 17)
                        {

                            for (int currentValueOfDealerHand = dealerHand[0].TheValue() + dealerHand[1].TheValue(); currentValueOfDealerHand < 17 && currentValueOfDealerHand <= 21; currentValueOfDealerHand = dealerHand[0].TheValue() + currentValueOfDealerHand)
                            {
                                dealerHand.Add(deckOfCards[0]);
                                int currentValueOfDealerHandAfterHit = currentValueOfDealerHand + dealerHand[0].TheValue();
                                Console.WriteLine($"The dealer got a {deckOfCards[0].RankAndSuit()} The current value of the dealer's hand is {currentValueOfDealerHandAfterHit}");
                                deckOfCards.Remove(deckOfCards[0]);
                                if (currentValueOfDealerHandAfterHit >= 17 && currentValueOfDealerHandAfterHit <= 21)
                                {
                                    if (currentValueOfHand < currentValueOfDealerHandAfterHit)
                                    {
                                        Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                        var playAgain = Console.ReadLine();
                                        if (playAgain == "yes" || playAgain == "Yes")
                                        {
                                            StartBlackJack();
                                        }
                                        if (playAgain == "No" || playAgain == "no")
                                        {
                                            Console.WriteLine($"Thank you for playing. Come back soon");
                                        }
                                    }
                                    if (currentValueOfHand > currentValueOfDealerHandAfterHit)
                                    {
                                        Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                        var playAgain = Console.ReadLine();
                                        if (playAgain == "yes" || playAgain == "Yes")
                                        {
                                            StartBlackJack();
                                        }
                                        if (playAgain == "No" || playAgain == "no")
                                        {
                                            Console.WriteLine($"Thank you for playing. Come back soon");
                                        }
                                    }
                                }
                                if (currentValueOfDealerHandAfterHit > 21)
                                {
                                    Console.WriteLine($"{playerOne} you win! The dealer has busted with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                    var playAgain = Console.ReadLine();
                                    if (playAgain == "yes" || playAgain == "Yes")
                                    {
                                        StartBlackJack();
                                    }
                                    if (playAgain == "No" || playAgain == "no")
                                    {
                                        Console.WriteLine($"Thank you for playing. Come back soon");
                                    }



                                }


                            }
                        }

                    }
                    if (takeHit == "yes" || takeHit == "Yes")
                    {
                        playerOneHand.Add(deckOfCards[0]);
                        Console.WriteLine(deckOfCards[0].RankAndSuit());
                        deckOfCards.Remove(deckOfCards[0]);
                        int currentValueOfHandAfterFirstHit = currentValueOfHand + playerOneHand[2].TheValue();
                        if (currentValueOfHandAfterFirstHit > 21)
                        {
                            Console.WriteLine($"Im sorry the value of your hand is {currentValueOfHandAfterFirstHit}, you have busted. Would you like to play again (Yes or No)?");
                            var playAgain = Console.ReadLine();
                            if (playAgain == "yes" || playAgain == "Yes")
                            {
                                StartBlackJack();
                            }
                        }

                        if (currentValueOfHandAfterFirstHit <= 21)
                        {
                            Console.WriteLine($" The Value of your two cards is {currentValueOfHandAfterFirstHit}. Would you like to take a hit (Yes or No)?");
                            var getSecondHit = Console.ReadLine();
                            if (getSecondHit == "No" || getSecondHit == "no")
                            {
                                Console.WriteLine($" Ok, now let's see the dealer's hand. The dealer has {dealerHand[0].RankAndSuit()} and {dealerHand[1].RankAndSuit()}");
                                for (int currentValueOfDealerHand = dealerHand[0].TheValue() + dealerHand[1].TheValue(); currentValueOfDealerHand < 17 && currentValueOfDealerHand <= 21; currentValueOfDealerHand = dealerHand[0].TheValue() + currentValueOfDealerHand)
                                {
                                    dealerHand.Add(deckOfCards[0]);
                                    int currentValueOfDealerHandAfterHit = currentValueOfDealerHand + dealerHand[0].TheValue();
                                    Console.WriteLine($"The dealer got a {deckOfCards[0].RankAndSuit()} The current value of the dealer's hand is {currentValueOfDealerHandAfterHit}");
                                    deckOfCards.Remove(deckOfCards[0]);
                                    if (currentValueOfDealerHandAfterHit >= 17 && currentValueOfDealerHandAfterHit <= 21)
                                    {
                                        if (currentValueOfHandAfterFirstHit < currentValueOfDealerHandAfterHit)
                                        {
                                            Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                            var playAgain = Console.ReadLine();
                                            if (playAgain == "yes" || playAgain == "Yes")
                                            {
                                                StartBlackJack();
                                            }
                                            if (playAgain == "No" || playAgain == "no")
                                            {
                                                Console.WriteLine($"Thank you for playing. Come back soon");
                                            }
                                        }
                                        if (currentValueOfHandAfterFirstHit > currentValueOfDealerHandAfterHit)
                                        {
                                            Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                            var playAgain = Console.ReadLine();
                                            if (playAgain == "yes" || playAgain == "Yes")
                                            {
                                                StartBlackJack();
                                            }
                                            if (playAgain == "No" || playAgain == "no")
                                            {
                                                Console.WriteLine($"Thank you for playing. Come back soon");
                                            }
                                        }
                                    }
                                    if (currentValueOfDealerHandAfterHit > 21)
                                    {
                                        Console.WriteLine($"{playerOne} you win! The dealer has busted with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                        var playAgain = Console.ReadLine();
                                        if (playAgain == "yes" || playAgain == "Yes")
                                        {
                                            StartBlackJack();
                                        }
                                        if (playAgain == "No" || playAgain == "no")
                                        {
                                            Console.WriteLine($"Thank you for playing. Come back soon");
                                        }



                                    }


                                }

                            }
                            if (getSecondHit == "Yes" || getSecondHit == "yes")
                            {
                                playerOneHand.Add(deckOfCards[0]);
                                Console.WriteLine(deckOfCards[0].RankAndSuit());
                                deckOfCards.Remove(deckOfCards[0]);
                                int currentValueOfHandAfterSecondHit = currentValueOfHandAfterFirstHit + playerOneHand[3].TheValue();
                                if (currentValueOfHandAfterSecondHit > 21)
                                {
                                    Console.WriteLine($"Im sorry the value of your hand is {currentValueOfHandAfterSecondHit}, you have busted. Would you like to play again (Yes or No)?");
                                    var playAgain = Console.ReadLine();
                                    if (playAgain == "yes" || playAgain == "Yes")
                                    {
                                        StartBlackJack();
                                    }
                                }
                                if (currentValueOfHandAfterSecondHit <= 21)
                                {
                                    Console.WriteLine($" The Value of your two cards is {currentValueOfHandAfterSecondHit}. Would you like to take a hit (Yes or No)?");
                                    var getThirdHit = Console.ReadLine();
                                    if (getThirdHit == "No" || getThirdHit == "no")
                                    {
                                        Console.WriteLine($" Ok, now let's see the dealer's hand. The dealer has {dealerHand[0].RankAndSuit()} and {dealerHand[1].RankAndSuit()}");
                                        for (int currentValueOfDealerHand = dealerHand[0].TheValue() + dealerHand[1].TheValue(); currentValueOfDealerHand < 17 && currentValueOfDealerHand <= 21; currentValueOfDealerHand = dealerHand[0].TheValue() + currentValueOfDealerHand)
                                        {
                                            dealerHand.Add(deckOfCards[0]);
                                            int currentValueOfDealerHandAfterHit = currentValueOfDealerHand + dealerHand[0].TheValue();
                                            Console.WriteLine($"The dealer got a {deckOfCards[0].RankAndSuit()} The current value of the dealer's hand is {currentValueOfDealerHandAfterHit}");
                                            deckOfCards.Remove(deckOfCards[0]);
                                            if (currentValueOfDealerHandAfterHit >= 17 && currentValueOfDealerHandAfterHit <= 21)
                                            {
                                                if (currentValueOfHandAfterSecondHit < currentValueOfDealerHandAfterHit)
                                                {
                                                    Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                    var playAgain = Console.ReadLine();
                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                    {
                                                        StartBlackJack();
                                                    }
                                                    if (playAgain == "No" || playAgain == "no")
                                                    {
                                                        Console.WriteLine($"Thank you for playing. Come back soon");
                                                    }
                                                }
                                                if (currentValueOfHandAfterSecondHit > currentValueOfDealerHandAfterHit)
                                                {
                                                    Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                                    var playAgain = Console.ReadLine();
                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                    {
                                                        StartBlackJack();
                                                    }
                                                    if (playAgain == "No" || playAgain == "no")
                                                    {
                                                        Console.WriteLine($"Thank you for playing. Come back soon");
                                                    }
                                                }
                                            }
                                            if (currentValueOfDealerHandAfterHit > 21)
                                            {
                                                Console.WriteLine($"{playerOne} you win! The dealer has busted with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                var playAgain = Console.ReadLine();
                                                if (playAgain == "yes" || playAgain == "Yes")
                                                {
                                                    StartBlackJack();
                                                }
                                                if (playAgain == "No" || playAgain == "no")
                                                {
                                                    Console.WriteLine($"Thank you for playing. Come back soon");
                                                }



                                            }


                                        }

                                    }
                                    if (getThirdHit == "Yes" || getThirdHit == "yes")
                                    {
                                        playerOneHand.Add(deckOfCards[0]);
                                        Console.WriteLine(deckOfCards[0].RankAndSuit());
                                        deckOfCards.Remove(deckOfCards[0]);
                                        int currentValueOfHandAfterThirdHit = currentValueOfHandAfterSecondHit + playerOneHand[4].TheValue();
                                        if (currentValueOfHandAfterThirdHit > 21)
                                        {
                                            Console.WriteLine($"Im sorry the value of your hand is {currentValueOfHandAfterThirdHit}, you have busted. Would you like to play again (Yes or No)?");
                                            var playAgain = Console.ReadLine();
                                            if (playAgain == "yes" || playAgain == "Yes")
                                            {
                                                StartBlackJack();
                                            }
                                        }
                                        if (currentValueOfHandAfterThirdHit <= 21)
                                        {
                                            Console.WriteLine($" The Value of your two cards is {currentValueOfHandAfterSecondHit}. Would you like to take a hit (Yes or No)?");
                                            var getFourthHit = Console.ReadLine();
                                            if (getFourthHit == "No" || getFourthHit == "no")
                                            {
                                                Console.WriteLine($" Ok, now let's see the dealer's hand. The dealer has {dealerHand[0].RankAndSuit()} and {dealerHand[1].RankAndSuit()}");
                                                for (int currentValueOfDealerHand = dealerHand[0].TheValue() + dealerHand[1].TheValue(); currentValueOfDealerHand < 17 && currentValueOfDealerHand <= 21; currentValueOfDealerHand = dealerHand[0].TheValue() + currentValueOfDealerHand)
                                                {
                                                    dealerHand.Add(deckOfCards[0]);
                                                    int currentValueOfDealerHandAfterHit = currentValueOfDealerHand + dealerHand[0].TheValue();
                                                    Console.WriteLine($"The dealer got a {deckOfCards[0].RankAndSuit()} The current value of the dealer's hand is {currentValueOfDealerHandAfterHit}");
                                                    deckOfCards.Remove(deckOfCards[0]);
                                                    if (currentValueOfDealerHandAfterHit >= 17 && currentValueOfDealerHandAfterHit <= 21)
                                                    {
                                                        if (currentValueOfHandAfterThirdHit < currentValueOfDealerHandAfterHit)
                                                        {
                                                            Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                            var playAgain = Console.ReadLine();
                                                            if (playAgain == "yes" || playAgain == "Yes")
                                                            {
                                                                StartBlackJack();
                                                            }
                                                            if (playAgain == "No" || playAgain == "no")
                                                            {
                                                                Console.WriteLine($"Thank you for playing. Come back soon");
                                                            }
                                                        }
                                                        if (currentValueOfHandAfterThirdHit > currentValueOfDealerHandAfterHit)
                                                        {
                                                            Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                                            var playAgain = Console.ReadLine();
                                                            if (playAgain == "yes" || playAgain == "Yes")
                                                            {
                                                                StartBlackJack();
                                                            }
                                                            if (playAgain == "No" || playAgain == "no")
                                                            {
                                                                Console.WriteLine($"Thank you for playing. Come back soon");
                                                            }
                                                        }
                                                    }
                                                    if (currentValueOfDealerHandAfterHit > 21)
                                                    {
                                                        Console.WriteLine($"{playerOne} you win! The dealer has busted with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                        var playAgain = Console.ReadLine();
                                                        if (playAgain == "yes" || playAgain == "Yes")
                                                        {
                                                            StartBlackJack();
                                                        }
                                                        if (playAgain == "No" || playAgain == "no")
                                                        {
                                                            Console.WriteLine($"Thank you for playing. Come back soon");
                                                        }



                                                    }


                                                }

                                            }
                                            if (getFourthHit == "Yes" || getFourthHit == "yes")
                                            {
                                                playerOneHand.Add(deckOfCards[0]);
                                                Console.WriteLine(deckOfCards[0].RankAndSuit());
                                                deckOfCards.Remove(deckOfCards[0]);
                                                int currentValueOfHandAfterFourthHit = currentValueOfHandAfterThirdHit + playerOneHand[5].TheValue();
                                                if (currentValueOfHandAfterFourthHit > 21)
                                                {
                                                    Console.WriteLine($"Im sorry the value of your hand is {currentValueOfHandAfterFourthHit}, you have busted. Would you like to play again (Yes or No)?");
                                                    var playAgain = Console.ReadLine();
                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                    {
                                                        StartBlackJack();
                                                    }
                                                }
                                                if (currentValueOfHandAfterFourthHit <= 21)
                                                {
                                                    Console.WriteLine($" The Value of your two cards is {currentValueOfHandAfterFourthHit}. Would you like to take a hit (Yes or No)?");
                                                    var getFifthHit = Console.ReadLine();
                                                    if (getFifthHit == "No" || getFifthHit == "no")
                                                    {
                                                        Console.WriteLine($" Ok, now let's see the dealer's hand. The dealer has {dealerHand[0].RankAndSuit()} and {dealerHand[1].RankAndSuit()}");
                                                        for (int currentValueOfDealerHand = dealerHand[0].TheValue() + dealerHand[1].TheValue(); currentValueOfDealerHand < 17 && currentValueOfDealerHand <= 21; currentValueOfDealerHand = dealerHand[0].TheValue() + currentValueOfDealerHand)
                                                        {
                                                            dealerHand.Add(deckOfCards[0]);
                                                            int currentValueOfDealerHandAfterHit = currentValueOfDealerHand + dealerHand[0].TheValue();
                                                            Console.WriteLine($"The dealer got a {deckOfCards[0].RankAndSuit()} The current value of the dealer's hand is {currentValueOfDealerHandAfterHit}");
                                                            deckOfCards.Remove(deckOfCards[0]);
                                                            if (currentValueOfDealerHandAfterHit >= 17 && currentValueOfDealerHandAfterHit <= 21)
                                                            {
                                                                if (currentValueOfHandAfterFourthHit < currentValueOfDealerHandAfterHit)
                                                                {
                                                                    Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                    var playAgain = Console.ReadLine();
                                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                                    {
                                                                        StartBlackJack();
                                                                    }
                                                                    if (playAgain == "No" || playAgain == "no")
                                                                    {
                                                                        Console.WriteLine($"Thank you for playing. Come back soon");
                                                                    }
                                                                }
                                                                if (currentValueOfHandAfterFourthHit > currentValueOfDealerHandAfterHit)
                                                                {
                                                                    Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                                                    var playAgain = Console.ReadLine();
                                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                                    {
                                                                        StartBlackJack();
                                                                    }
                                                                    if (playAgain == "No" || playAgain == "no")
                                                                    {
                                                                        Console.WriteLine($"Thank you for playing. Come back soon");
                                                                    }
                                                                }
                                                            }
                                                            if (currentValueOfDealerHandAfterHit > 21)
                                                            {
                                                                Console.WriteLine($"{playerOne} you win! The dealer has busted with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                var playAgain = Console.ReadLine();
                                                                if (playAgain == "yes" || playAgain == "Yes")
                                                                {
                                                                    StartBlackJack();
                                                                }
                                                                if (playAgain == "No" || playAgain == "no")
                                                                {
                                                                    Console.WriteLine($"Thank you for playing. Come back soon");
                                                                }



                                                            }


                                                        }

                                                    }
                                                    if (getFifthHit == "Yes" || getFifthHit == "yes")
                                                    {
                                                        playerOneHand.Add(deckOfCards[0]);
                                                        Console.WriteLine(deckOfCards[0].RankAndSuit());
                                                        deckOfCards.Remove(deckOfCards[0]);
                                                        int currentValueOfHandAfterFifthHit = currentValueOfHandAfterFourthHit + playerOneHand[6].TheValue();
                                                        if (currentValueOfHandAfterFifthHit > 21)
                                                        {
                                                            Console.WriteLine($"Im sorry the value of your hand is {currentValueOfHandAfterFifthHit}, you have busted. Would you like to play again (Yes or No)?");
                                                            var playAgain = Console.ReadLine();
                                                            if (playAgain == "yes" || playAgain == "Yes")
                                                            {
                                                                StartBlackJack();
                                                            }
                                                        }
                                                        if (currentValueOfHandAfterFifthHit <= 21)
                                                        {
                                                            Console.WriteLine($" The Value of your two cards is {currentValueOfHandAfterFifthHit}. Would you like to take a hit (Yes or No)?");
                                                            var getSixthHit = Console.ReadLine();
                                                            if (getSixthHit == "No" || getSixthHit == "no")
                                                            {
                                                                Console.WriteLine($" Ok, now let's see the dealer's hand. The dealer has {dealerHand[0].RankAndSuit()} and {dealerHand[1].RankAndSuit()}");
                                                                for (int currentValueOfDealerHand = dealerHand[0].TheValue() + dealerHand[1].TheValue(); currentValueOfDealerHand < 17 && currentValueOfDealerHand <= 21; currentValueOfDealerHand = dealerHand[0].TheValue() + currentValueOfDealerHand)
                                                                {
                                                                    dealerHand.Add(deckOfCards[0]);
                                                                    int currentValueOfDealerHandAfterHit = currentValueOfDealerHand + dealerHand[0].TheValue();
                                                                    Console.WriteLine($"The dealer got a {deckOfCards[0].RankAndSuit()} The current value of the dealer's hand is {currentValueOfDealerHandAfterHit}");
                                                                    deckOfCards.Remove(deckOfCards[0]);
                                                                    if (currentValueOfDealerHandAfterHit >= 17 && currentValueOfDealerHandAfterHit <= 21)
                                                                    {
                                                                        if (currentValueOfHandAfterFifthHit < currentValueOfDealerHandAfterHit)
                                                                        {
                                                                            Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                            var playAgain = Console.ReadLine();
                                                                            if (playAgain == "yes" || playAgain == "Yes")
                                                                            {
                                                                                StartBlackJack();
                                                                            }
                                                                            if (playAgain == "No" || playAgain == "no")
                                                                            {
                                                                                Console.WriteLine($"Thank you for playing. Come back soon");
                                                                            }
                                                                        }
                                                                        if (currentValueOfHandAfterFifthHit > currentValueOfDealerHandAfterHit)
                                                                        {
                                                                            Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                                                            var playAgain = Console.ReadLine();
                                                                            if (playAgain == "yes" || playAgain == "Yes")
                                                                            {
                                                                                StartBlackJack();
                                                                            }
                                                                            if (playAgain == "No" || playAgain == "no")
                                                                            {
                                                                                Console.WriteLine($"Thank you for playing. Come back soon");
                                                                            }
                                                                        }
                                                                    }
                                                                    if (currentValueOfDealerHandAfterHit > 21)
                                                                    {
                                                                        Console.WriteLine($"{playerOne} you win! The dealer has busted with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                        var playAgain = Console.ReadLine();
                                                                        if (playAgain == "yes" || playAgain == "Yes")
                                                                        {
                                                                            StartBlackJack();
                                                                        }
                                                                        if (playAgain == "No" || playAgain == "no")
                                                                        {
                                                                            Console.WriteLine($"Thank you for playing. Come back soon");
                                                                        }



                                                                    }


                                                                }

                                                            }
                                                            if (getSixthHit == "Yes" || getSixthHit == "yes")
                                                            {
                                                                playerOneHand.Add(deckOfCards[0]);
                                                                Console.WriteLine(deckOfCards[0].RankAndSuit());
                                                                deckOfCards.Remove(deckOfCards[0]);
                                                                int currentValueOfHandAfterSixthHit = currentValueOfHandAfterFifthHit + playerOneHand[7].TheValue();
                                                                if (currentValueOfHandAfterSixthHit > 21)
                                                                {
                                                                    Console.WriteLine($"Im sorry the value of your hand is {currentValueOfHandAfterSixthHit}, you have busted. Would you like to play again (Yes or No)?");
                                                                    var playAgain = Console.ReadLine();
                                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                                    {
                                                                        StartBlackJack();
                                                                    }
                                                                }
                                                                if (currentValueOfHandAfterSixthHit <= 21)
                                                                {
                                                                    Console.WriteLine($" The Value of your two cards is {currentValueOfHandAfterSixthHit}. Would you like to take a hit (Yes or No)?");
                                                                    var getSeventhHit = Console.ReadLine();
                                                                    if (getSeventhHit == "No" || getSeventhHit == "no")
                                                                    {
                                                                        Console.WriteLine($" Ok, now let's see the dealer's hand. The dealer has {dealerHand[0].RankAndSuit()} and {dealerHand[1].RankAndSuit()}");
                                                                        for (int currentValueOfDealerHand = dealerHand[0].TheValue() + dealerHand[1].TheValue(); currentValueOfDealerHand < 17 && currentValueOfDealerHand <= 21; currentValueOfDealerHand = dealerHand[0].TheValue() + currentValueOfDealerHand)
                                                                        {
                                                                            dealerHand.Add(deckOfCards[0]);
                                                                            int currentValueOfDealerHandAfterHit = currentValueOfDealerHand + dealerHand[0].TheValue();
                                                                            Console.WriteLine($"The dealer got a {deckOfCards[0].RankAndSuit()} The current value of the dealer's hand is {currentValueOfDealerHandAfterHit}");
                                                                            deckOfCards.Remove(deckOfCards[0]);
                                                                            if (currentValueOfDealerHandAfterHit >= 17 && currentValueOfDealerHandAfterHit <= 21)
                                                                            {
                                                                                if (currentValueOfHandAfterSixthHit < currentValueOfDealerHandAfterHit)
                                                                                {
                                                                                    Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                                    var playAgain = Console.ReadLine();
                                                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                                                    {
                                                                                        StartBlackJack();
                                                                                    }
                                                                                    if (playAgain == "No" || playAgain == "no")
                                                                                    {
                                                                                        Console.WriteLine($"Thank you for playing. Come back soon");
                                                                                    }
                                                                                }
                                                                                if (currentValueOfHandAfterSixthHit > currentValueOfDealerHandAfterHit)
                                                                                {
                                                                                    Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                                                                    var playAgain = Console.ReadLine();
                                                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                                                    {
                                                                                        StartBlackJack();
                                                                                    }
                                                                                    if (playAgain == "No" || playAgain == "no")
                                                                                    {
                                                                                        Console.WriteLine($"Thank you for playing. Come back soon");
                                                                                    }
                                                                                }
                                                                            }
                                                                            if (currentValueOfDealerHandAfterHit > 21)
                                                                            {
                                                                                Console.WriteLine($"{playerOne} you win! The dealer has busted with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                                var playAgain = Console.ReadLine();
                                                                                if (playAgain == "yes" || playAgain == "Yes")
                                                                                {
                                                                                    StartBlackJack();
                                                                                }
                                                                                if (playAgain == "No" || playAgain == "no")
                                                                                {
                                                                                    Console.WriteLine($"Thank you for playing. Come back soon");
                                                                                }



                                                                            }


                                                                        }

                                                                    }
                                                                    if (getSeventhHit == "no" || getSeventhHit == "No")
                                                                    {
                                                                        Console.WriteLine($" Ok, now let's see the dealer's hand. The dealer has {dealerHand[0].RankAndSuit()} and {dealerHand[1].RankAndSuit()}");
                                                                        for (int currentValueOfDealerHand = dealerHand[0].TheValue() + dealerHand[1].TheValue(); currentValueOfDealerHand < 17 && currentValueOfDealerHand <= 21; currentValueOfDealerHand = dealerHand[0].TheValue() + currentValueOfDealerHand)
                                                                        {
                                                                            dealerHand.Add(deckOfCards[0]);
                                                                            int currentValueOfDealerHandAfterHit = currentValueOfDealerHand + dealerHand[0].TheValue();
                                                                            Console.WriteLine($"The dealer got a {deckOfCards[0].RankAndSuit()} The current value of the dealer's hand is {currentValueOfDealerHandAfterHit}");
                                                                            deckOfCards.Remove(deckOfCards[0]);
                                                                            if (currentValueOfDealerHandAfterHit >= 17 && currentValueOfDealerHandAfterHit <= 21)
                                                                            {
                                                                                if (currentValueOfHandAfterSixthHit < currentValueOfDealerHandAfterHit)
                                                                                {
                                                                                    Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                                    var playAgain = Console.ReadLine();
                                                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                                                    {
                                                                                        StartBlackJack();
                                                                                    }
                                                                                    if (playAgain == "No" || playAgain == "no")
                                                                                    {
                                                                                        Console.WriteLine($"Thank you for playing. Come back soon");
                                                                                    }
                                                                                }
                                                                                if (currentValueOfHandAfterSixthHit > currentValueOfDealerHandAfterHit)
                                                                                {
                                                                                    Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                                                                    var playAgain = Console.ReadLine();
                                                                                    if (playAgain == "yes" || playAgain == "Yes")
                                                                                    {
                                                                                        StartBlackJack();
                                                                                    }
                                                                                    if (playAgain == "No" || playAgain == "no")
                                                                                    {
                                                                                        Console.WriteLine($"Thank you for playing. Come back soon");
                                                                                    }
                                                                                }
                                                                            }
                                                                            if (currentValueOfDealerHandAfterHit > 21)
                                                                            {
                                                                                Console.WriteLine($"{playerOne} you win! The dealer has busted with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                                var playAgain = Console.ReadLine();
                                                                                if (playAgain == "yes" || playAgain == "Yes")
                                                                                {
                                                                                    StartBlackJack();
                                                                                }
                                                                                if (playAgain == "No" || playAgain == "no")
                                                                                {
                                                                                    Console.WriteLine($"Thank you for playing. Come back soon");
                                                                                }



                                                                            }


                                                                        }
                                                                        if (getSeventhHit == "Yes" || getSeventhHit == "yes")
                                                                        {
                                                                            playerOneHand.Add(deckOfCards[0]);
                                                                            Console.WriteLine(deckOfCards[0].RankAndSuit());
                                                                            deckOfCards.Remove(deckOfCards[0]);
                                                                            int currentValueOfHandAfterSeventhHit = currentValueOfHandAfterSixthHit + playerOneHand[8].TheValue();
                                                                            if (currentValueOfHandAfterSeventhHit <= 21)
                                                                            {
                                                                                Console.WriteLine($" Ok, now let's see the dealer's hand. The dealer has {dealerHand[0].RankAndSuit()} and {dealerHand[1].RankAndSuit()}");
                                                                                for (int currentValueOfDealerHand = dealerHand[0].TheValue() + dealerHand[1].TheValue(); currentValueOfDealerHand < 17 && currentValueOfDealerHand <= 21; currentValueOfDealerHand = dealerHand[0].TheValue() + currentValueOfDealerHand)
                                                                                {
                                                                                    dealerHand.Add(deckOfCards[0]);
                                                                                    int currentValueOfDealerHandAfterHit = currentValueOfDealerHand + dealerHand[0].TheValue();
                                                                                    Console.WriteLine($"The dealer got a {deckOfCards[0].RankAndSuit()} The current value of the dealer's hand is {currentValueOfDealerHandAfterHit}");
                                                                                    deckOfCards.Remove(deckOfCards[0]);
                                                                                    if (currentValueOfDealerHandAfterHit >= 17 && currentValueOfDealerHandAfterHit <= 21)
                                                                                    {
                                                                                        if (currentValueOfHandAfterSeventhHit < currentValueOfDealerHandAfterHit)
                                                                                        {
                                                                                            Console.WriteLine($"I'm sorry you lost. The dealer won with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                                            var playAgain = Console.ReadLine();
                                                                                            if (playAgain == "yes" || playAgain == "Yes")
                                                                                            {
                                                                                                StartBlackJack();
                                                                                            }
                                                                                            if (playAgain == "No" || playAgain == "no")
                                                                                            {
                                                                                                Console.WriteLine($"Thank you for playing. Come back soon");
                                                                                            }
                                                                                        }
                                                                                        if (currentValueOfHandAfterSeventhHit > currentValueOfDealerHandAfterHit)
                                                                                        {
                                                                                            Console.WriteLine("you won! Would you like to play again (Yes or no)?");
                                                                                            var playAgain = Console.ReadLine();
                                                                                            if (playAgain == "yes" || playAgain == "Yes")
                                                                                            {
                                                                                                StartBlackJack();
                                                                                            }
                                                                                            if (playAgain == "No" || playAgain == "no")
                                                                                            {
                                                                                                Console.WriteLine($"Thank you for playing. Come back soon");
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    if (currentValueOfDealerHandAfterHit > 21)
                                                                                    {
                                                                                        Console.WriteLine($"{playerOne} you win! The dealer has busted with a value of {currentValueOfDealerHandAfterHit}. Would you like to play again (Yes or No)?");
                                                                                        var playAgain = Console.ReadLine();
                                                                                        if (playAgain == "yes" || playAgain == "Yes")
                                                                                        {
                                                                                            StartBlackJack();
                                                                                        }
                                                                                        if (playAgain == "No" || playAgain == "no")
                                                                                        {
                                                                                            Console.WriteLine($"Thank you for playing. Come back soon");
                                                                                        }



                                                                                    }


                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }


                                                        }

                                                    }

                                                }

                                            }
                                        }

                                    }

                                }


                            }
                        }
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            StartBlackJack();

        }
    }
}



//created the card class
class Card
{
    public string Rank
    {
        get; set;
    }
    public string Suit
    {
        get; set;
    }
    public int TheValue()
    {
        if (Rank == "Ace")
        {
            return 11;
        }

        if (Rank == "King")
        {
            return 10;
        }

        if (Rank == "Queen")
        {
            return 10;
        }

        if (Rank == "Jack")
        {
            return 10;
        }

        if (Rank == "Ten")
        {
            return 10;
        }

        if (Rank == "Nine")
        {
            return 9;
        }

        if (Rank == "Eight")
        {
            return 8;
        }

        if (Rank == "Seven")
        {
            return 7;
        }

        if (Rank == "Six")
        {
            return 6;
        }

        if (Rank == "Five")
        {
            return 5;
        }

        if (Rank == "Four")
        {
            return 4;
        }

        if (Rank == "Three")
        {
            return 3;
        }

        if (Rank == "Two")
        {
            return 2;
        }

        return 0;
    }
    public string RankAndSuit()
    {
        return $"The {Rank} of {Suit}";
    }
}