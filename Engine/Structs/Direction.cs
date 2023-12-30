namespace SnakeGame
{
    public readonly struct Direction(int ColumnOffset, int RowOffset)
    {
        public int RowOffset { get; } = RowOffset;
        public int ColumnOffset { get; } = ColumnOffset;
    }
}
