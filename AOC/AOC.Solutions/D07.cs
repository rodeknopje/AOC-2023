namespace AOC.Solutions;

public class D07 : DayBase
{
    protected override int Day => 7;

    
    
    public override long Solve_1()
    {
        var hands = GetInputLines().Select(line => (cards: line.Split(" ").First(), bid: int.Parse(line.Split(" ").Last()))).ToList();

        var cardScore = new Dictionary<char, int>()
        {
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'T', 10 },
            { 'J', 11 },
            { 'Q', 12 },
            { 'K', 13 },
            { 'A', 14 },
        };
        
        return hands
            // 5 of a kind
            .OrderBy(hand => hand.cards.Max(x => hand.cards.Count(a => x == a) == 5))
            // 4 of a kind
            .ThenBy(hand => hand.cards.Max(x => hand.cards.Count(a => x == a) == 4))
            // full house
            .ThenBy(hand => hand.cards.Max(x => hand.cards.Count(a => x == a) == 3 && hand.cards.Distinct().Count() == 2 ))
            // three of a kind
            .ThenBy(hand => hand.cards.Max(x => hand.cards.Count(a => x == a) == 3))
            // two pair
            .ThenBy(hand => hand.cards.Max(x => hand.cards.Count(a => x == a) == 2) && hand.cards.Distinct().Count() == 3)
            // one pair
            .ThenBy(hand => hand.cards.Max(x => hand.cards.Count(a => x == a) == 2) && hand.cards.Distinct().Count() == 4)
            // high card
            .ThenBy(hand => cardScore[hand.cards[0]])
            .ThenBy(hand => cardScore[hand.cards[1]])
            .ThenBy(hand => cardScore[hand.cards[2]])
            .ThenBy(hand => cardScore[hand.cards[3]])
            .ThenBy(hand => cardScore[hand.cards[4]])
            .Select((hand,i) => hand.bid * (i + 1)).Sum();
        
    }

    public override long Solve_2()
    {
        var hands = GetInputLines().Select(line => (cards: line.Split(" ").First(), bid: int.Parse(line.Split(" ").Last()), jokerHand: "")).ToList();

        var cardScore = new Dictionary<char, int>()
        {
            { 'J', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 }, { 'T', 10 }, { 'Q', 11 }, { 'K', 12 }, { 'A', 13 },
        };
        
        return hands.Select(hand => {
                var winningCard = hand.cards ==  "JJJJJ" ? 'A' : hand.cards.Replace("J","").MaxBy(card => hand.cards.Count(x => x == card) * 100 + cardScore[card]);
                hand.jokerHand = hand.cards.Replace("J", winningCard.ToString());
                return hand;
            })
            // 5 of a kind
            .OrderBy(hand => hand.jokerHand.Max(x => hand.jokerHand.Count(a => x == a) == 5))
            // 4 of a kind
            .ThenBy(hand => hand.jokerHand.Max(x => hand.jokerHand.Count(a => x == a) == 4))
            // full house
            .ThenBy(hand => hand.jokerHand.Max(x => hand.jokerHand.Count(a => x == a) == 3 && hand.jokerHand.Distinct().Count() == 2 ))
            // three of a kind
            .ThenBy(hand => hand.jokerHand.Max(x => hand.jokerHand.Count(a => x == a) == 3))
            // two pair
            .ThenBy(hand => hand.jokerHand.Max(x => hand.jokerHand.Count(a => x == a) == 2) && hand.jokerHand.Distinct().Count() == 3)
            // one pair
            .ThenBy(hand => hand.jokerHand.Max(x => hand.jokerHand.Count(a => x == a) == 2) && hand.jokerHand.Distinct().Count() == 4)
            // high card
            .ThenBy(hand => cardScore[hand.cards[0]])
            .ThenBy(hand => cardScore[hand.cards[1]])
            .ThenBy(hand => cardScore[hand.cards[2]])
            .ThenBy(hand => cardScore[hand.cards[3]])
            .ThenBy(hand => cardScore[hand.cards[4]])
            .Select((hand,i) => hand.bid * (i + 1)).Sum();
    }
}