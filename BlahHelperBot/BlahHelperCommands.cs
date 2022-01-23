using Discord.Commands;

namespace BlahHelperBot
{
    // Keep in mind your module **must** be public and inherit ModuleBase.
    // If it isn't, it will not be discovered by AddModulesAsync!
    [Group("blah")]
    public class BlahHelperCommands : ModuleBase<SocketCommandContext>
    {
        // ~say hello world -> hello world
        [Command("say")]
        [Summary("Echoes a message.")]
        public Task SayAsync([Remainder][Summary("The text to echo")] string echo)
        {
            return ReplyAsync(echo);
        }

        [Command("sayNumber")]
        [Summary("echoes a message with a number")]
        public Task SayAsync([Summary("number to echo")] int number, [Remainder][Summary("The text to echo")] string echo)
        {
            return ReplyAsync(number.ToString() + " hi " + echo);
        }

        //takes a bit sale ad and a cost per bit 
        //returns the message needed to enter the necessary bits into a karuta trade as well as the cost of the bits
        [Command("buy")]
        [Summary("buys bits")]
        public async Task BuyBits([Summary("rate to buy bits")] int bitRate, [Remainder][Summary("the sale ad")] string bitAd)
        {
            string[] bitTypes = new string[] {
                "essence", "iron", "salt", "uranium", "leaf", "magma", "clay", "wax", "wool", "flower",
                "oil", "bone", "copper", "ice", "quartz", "stone", "sugar", "wood", "zinc"
            };

            int totalCost = 0;
            string finalSale = "";

            //remove all spaces and punctuation from the bit ad and change to lowercase
            bitAd = new string(bitAd.Where(c => !(char.IsPunctuation(c)||char.IsWhiteSpace(c))).ToArray()).ToLower();


            //Every time we find numbers in the bit ad, we will then look for a valid bit type after that number.
            //If we find a valid bit type, then we will assume that the number indicates the amount of that bit.
            //We will buy as many bits as possible of that type of bit at a specified rate
            string curDigits = "";
            for (int i = 0; i <bitAd.Length; i++)
            {
                if (char.IsDigit(bitAd[i]))
                {
                    curDigits += bitAd[i];
                }
                else if (!curDigits.Equals(""))
                {
                    foreach (string bitType in bitTypes)
                    {
                        if (bitAd.IndexOf(bitType, i) == i)
                        {
                            int bitTotal = int.Parse(curDigits);
                            int ticketCost = bitTotal / bitRate;
                            totalCost += ticketCost;
                            if (ticketCost > 0)
                            {
                                finalSale += (bitRate * ticketCost).ToString() + " " + bitType + " bit, ";
                            }
                            break;
                        }
                    }
                    curDigits = "";
                }
            }

            if(finalSale.Length == 0)
            {
                finalSale = "fail";
            }
            else
            {
                finalSale = finalSale + "\n\nfor " + totalCost.ToString() + " tickets";
            }

            await ReplyAsync(finalSale);
        }
    }
}
