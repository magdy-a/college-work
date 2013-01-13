namespace SecurityLibrary
{
    /// <summary>
    /// Helper Functions for Cryptography
    /// </summary>
    public class HF
    {
        public static int GetIndex(char c)
        {
            return Cryptography.ENGLISHCHARACTERS.IndexOf(char.ToLower(c));
        }

        public static char getChar(int index)
        {
            char tmpChar = '\0';

            if (index >= 0 && index < Cryptography.NUMENGLISHCHARACTERS)
            {
                tmpChar = Cryptography.ENGLISHCHARACTERS[index];
            }

            return tmpChar;
        }

        public static uint CircularRightShift(uint a, int shifts)
        {
            // Set mirror to "0"
            uint mirror = 0;

            // Set printer to 31 "0" Then 1 "1" **********
            uint printer = 0x0001;

            // for the number of numOfShifts, set the most right******** bits in mirror to "1"
            for (int i = 0; i < shifts; i++)
            {
                // ORing "0" | "1", gets "1"
                mirror = mirror | printer;

                // Shift the "1" in the printer
                printer = printer << 1;
            }

            // ANDing mirror and the input value, will get the most right******* bits by the number of numOfShifts
            mirror = mirror & a;

            // Shift mirror by 32 - #numOfShifts, so that u get the values to the most left*******
            mirror = mirror << (32 - shifts);

            // Shift a
            a = a >> shifts;

            // then add the missing bits to the most left ****** of a
            a = a | mirror;

            return a;
        }

        public static uint CircularLeftShift(uint a, int shifts)
        {
            // Set mirror to "0"
            uint mirror = 0;

            // Set printer to "1" then 31 "0"
            uint printer = 0x8000;

            // for the number of numOfShifts, set the most left bits in mirror to "1"
            for (int i = 0; i < shifts; i++)
            {
                // ORing "0" | "1", gets "1"
                mirror = mirror | printer;

                // Shift the "1" in the printer
                printer = printer >> 1;
            }

            // ANDing mirror and the input value, will get the most left bits by the number of numOfShifts
            mirror = mirror & a;

            // Shift mirror by 32 - #numOfShifts, so that u get the values to the most right
            mirror = mirror >> (32 - shifts);

            // Shift a
            a = a << shifts;

            // then add the missing bits to the most right of a
            a = a | mirror;

            return a;
        }
    }
}