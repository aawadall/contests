namespace Sol1
{
    public class Solution
    {
        public bool Debug { get; set; }
        private static char[] _balloon = { 'b', 'a', 'l', 'l', 'o', 'o', 'n' };
        public int MaxNumberOfBalloons(string text) {
            int count = 0;
            bool found = true;

            while(found && text.Length > 0) {
                foreach (char letter in _balloon)
                {
                    if(text.Contains(letter)) {
                        int index = text.IndexOf(letter);
                        text = text.Remove(index, 1);
                        if(Debug) System.Console.WriteLine($"count:{count}\tletter:{letter}\ttext:{text}");
                    } else {
                        found = false;
                    }
                }
                count += found ? 1 : 0;
            }

            return count; 
        }
    }
}