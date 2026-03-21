namespace FaHIconAPI.Services
{
    public static class FormatService
    {
        public static string ToBadgeNumber(long value)
        {
            var abs = Math.Abs((double)value);
            var sign = value < 0 ? "-" : "";

            return abs switch
            {
                >= 1_000_000_000_000 => $"{sign}{abs / 1_000_000_000_000:0.#}T",
                >= 1_000_000_000 => $"{sign}{abs / 1_000_000_000:0.#}B",
                >= 1_000_000 => $"{sign}{abs / 1_000_000:0.#}M",
                >= 1_000 => $"{sign}{abs / 1_000:0.#}K",
                _ => value.ToString()
            };
        }

        public static string ToPlaceNumber(long value)
        {
            var abs = Math.Abs((double)value);
            var sign = value < 0 ? "-" : "";

            return abs switch
            {
                >= 1_000_000_000_000 => $"{sign}{abs / 1_000_000_000_000:0.#}T",
                >= 1_000_000_000 => $"{sign}{abs / 1_000_000_000:0.#}B",
                >= 1_000_000 => $"{sign}{abs / 1_000_000:0.#}M",
                >= 1_000 => $"{sign}{abs / 1_000:0.#}K",
                _ => value.ToString()
            };
        }
    }
}
