namespace SnakeGame
{
    public readonly struct Direction(int RowOffset, int ColumnOffset)
    {
        public int RowOffset { get; } = RowOffset;
        public int ColumnOffset { get; } = ColumnOffset;
    }
}
