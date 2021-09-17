namespace _985_sum_of_even_numbers_after_queries
{
    public interface ISolution
    {
        bool EnableDebug { get; set; }
        int[] SumEvenAfterQueries(int[] nums, int[][] queries);
    }
}