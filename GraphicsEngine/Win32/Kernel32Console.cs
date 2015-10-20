#region Imports

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

#endregion

// http://stackoverflow.com/questions/2754518/how-can-i-write-fast-colored-output-to-console
// http://blog.tedd.no/2015/08/02/better-text-console-for-c/

namespace GraphicsEngine.Win32
{
	internal static class Kernel32Console
	{
		public const int STD_INPUT_HANDLE = unchecked((int)(-10));
		public const int STD_OUTPUT_HANDLE = unchecked((int)(-11));
		public const int STD_ERROR_HANDLE = unchecked((int)(-12));

		public static class Colors
		{
			public const short FOREGROUND_BLACK = 0x0000;
			public const short FOREGROUND_BLUE = 0x0001;
			public const short FOREGROUND_GREEN = 0x0002;
			public const short FOREGROUND_CYAN = 0x0003;
			public const short FOREGROUND_RED = 0x0004;
			public const short FOREGROUND_MAGENTA = 0x0005;
			public const short FOREGROUND_YELLOW = 0x0006;
			public const short FOREGROUND_GREY = 0x0007;
			public const short FOREGROUND_INTENSITY = 0x0008;

			public const short BACKGROUND_BLACK = 0x0000;
			public const short BACKGROUND_BLUE = 0x0010;
			public const short BACKGROUND_GREEN = 0x0020;
			public const short BACKGROUND_CYAN = 0x0030;
			public const short BACKGROUND_RED = 0x0040;
			public const short BACKGROUND_MAGENTA = 0x0050;
			public const short BACKGROUND_YELLOW = 0x0060;
			public const short BACKGROUND_GREY = 0x0070;
			public const short BACKGROUND_INTENSITY = 0x0080;
		}

		public const ushort COMMON_LVB_LEADING_BYTE = 0x0100;
		public const ushort COMMON_LVB_TRAILING_BYTE = 0x0200;
		public const ushort COMMON_LVB_GRID_HORIZONTAL = 0x0400;
		public const ushort COMMON_LVB_GRID_LVERTICAL = 0x0800;
		public const ushort COMMON_LVB_GRID_RVERTICAL = 0x1000;
		public const ushort COMMON_LVB_REVERSE_VIDEO = 0x4000;
		public const ushort COMMON_LVB_UNDERSCORE = 0x8000;
		public const ushort COMMON_LVB_SBCSDBCS = 0x0300;

		[DllImport("kernel32.dll", EntryPoint = "ReadConsoleInputW", CharSet = CharSet.Unicode)]
		public static extern bool ReadConsoleInput(
			IntPtr hConsoleInput,
			[Out] INPUT_RECORD[] lpBuffer,
			uint nLength,
			out uint lpNumberOfEventsRead
			);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool GetNumberOfConsoleInputEvents(
			IntPtr hConsoleInput,
			out uint lpcNumberOfEvents
			);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool GetNumberOfConsoleMouseButtons(
			ref uint lpNumberOfMouseButtons
			);

		[DllImport("user32.dll")]
		public static extern int ShowCursor(bool bShow);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorPos(out COORD lpPoint);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetStdHandle(
			int nStdHandle
			);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetConsoleWindow();

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool SetConsoleCursorPosition(
			IntPtr hConsoleOutput,
			COORD dwCursorPosition
			);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetWindowRect(IntPtr hwnd, out SMALL_RECT lpRect);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool GetConsoleScreenBufferInfoEx(
			IntPtr hConsoleOutput,
			ref CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfo
			);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteConsoleOutput(
			IntPtr hConsoleOutput,
			CHAR_INFO[] lpBuffer,
			COORD dwBufferSize,
			COORD dwBufferCoord,
			ref SMALL_RECT lpWriteRegion
			);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool SetCurrentConsoleFontEx(
			IntPtr ConsoleOutput,
			bool MaximumWindow,
			Kernel32Console.CONSOLE_FONT_INFO_EX ConsoleCurrentFontEx
			);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool SetConsoleScreenBufferInfoEx(
			IntPtr ConsoleOutput,
			ref CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfoEx
			);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint GetConsoleTitle(
			[Out] StringBuilder lpConsoleTitle,
			uint nSize
			);	

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool SetConsoleTitle(
			string lpConsoleTitle
			);

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct CONSOLE_FONT_INFO_EX
		{
			public uint cbSize;
			public uint nFont;
			public Kernel32Console.COORD dwFontSize;
			public ushort FontFamily;
			public ushort FontWeight;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public fixed char FaceName[LF_FACESIZE];

			public const int LF_FACESIZE = 32;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct INPUT_RECORD
		{
			[FieldOffset(0)]
			public ushort EventType;

			[FieldOffset(4)]
			public KEY_EVENT_RECORD KeyEvent;

			[FieldOffset(4)]
			public MOUSE_EVENT_RECORD MouseEvent;

			[FieldOffset(4)]
			public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;

			[FieldOffset(4)]
			public MENU_EVENT_RECORD MenuEvent;

			[FieldOffset(4)]
			public FOCUS_EVENT_RECORD FocusEvent;
		};

		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct KEY_EVENT_RECORD
		{
			[FieldOffset(0)]
			[MarshalAs(UnmanagedType.Bool)]
			public bool bKeyDown;

			[FieldOffset(4)]
			[MarshalAs(UnmanagedType.U2)]
			public ushort wRepeatCount;

			[FieldOffset(6)]
			[MarshalAs(UnmanagedType.U2)]
			//public VirtualKeys wVirtualKeyCode;
			public ushort wVirtualKeyCode;

			[FieldOffset(8)]
			[MarshalAs(UnmanagedType.U2)]
			public ushort wVirtualScanCode;

			[FieldOffset(10)]
			public char UnicodeChar;

			[FieldOffset(12)]
			[MarshalAs(UnmanagedType.U4)]
			//public ControlKeyState dwControlKeyState;
			public uint dwControlKeyState;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MOUSE_EVENT_RECORD
		{
			public COORD dwMousePosition;
			public uint dwButtonState;
			public uint dwControlKeyState;
			public uint dwEventFlags;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct WINDOW_BUFFER_SIZE_RECORD
		{
			public COORD dwSize;

			public WINDOW_BUFFER_SIZE_RECORD(short x, short y)
			{
				dwSize = new COORD(x, y);
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MENU_EVENT_RECORD
		{
			public uint dwCommandId;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct FOCUS_EVENT_RECORD
		{
			public uint bSetFocus;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct CONSOLE_SCREEN_BUFFER_INFO_EX
		{
			public uint cbSize;
			public COORD dwSize;
			public COORD dwCursorPosition;
			public short wAttributes;
			public SMALL_RECT srWindow;
			public COORD dwMaximumWindowSize;
			public ushort wPopupAttributes;
			public bool bFullscreenSupported;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public COLORREF[] ColorTable;

			public static CONSOLE_SCREEN_BUFFER_INFO_EX Create()
			{
				return new CONSOLE_SCREEN_BUFFER_INFO_EX { cbSize = 96 };
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct COLORREF
		{
			public uint ColorDWORD;

			public COLORREF(Color color)
			{
				ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
			}

			public COLORREF(uint dword)
			{
				ColorDWORD = dword;
			}

			public Color GetColor()
			{
				return Color.FromArgb(R, G, B);
			}

			public int R
			{
				get { return (int) (0x000000FFU & ColorDWORD); }
			}

			public int G
			{
				get { return (int)(0x0000FF00U & ColorDWORD) >> 8; }
			}

			public int B
			{
				get { return (int)(0x00FF0000U & ColorDWORD) >> 16; }
			}

			public void SetColor(Color color)
			{
				ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct COORD
		{
			public readonly short X;
			public readonly short Y;

			public COORD(short X, short Y)
			{
				this.X = X;
				this.Y = Y;
			}

			public COORD(int X, int Y)
			{
				this.X = (short)X;
				this.Y = (short)Y;
			}
		};

		[StructLayout(LayoutKind.Explicit)]
		public struct CHAR_UNION
		{
			public CHAR_UNION(char unicodeChar)
			{
				UnicodeChar = unicodeChar;
				AsciiChar = (byte)UnicodeChar;
			}

			public CHAR_UNION(char unicodeChar, byte asciiChar)
			{
				UnicodeChar = unicodeChar;
				AsciiChar = asciiChar;
			}

			[FieldOffset(0)]
			public char UnicodeChar;

			[FieldOffset(0)]
			public byte AsciiChar;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct CHAR_INFO
		{
			public CHAR_INFO(CHAR_UNION character, short attributes)
			{
				Char = character;
				Attributes = attributes;
			}

			[FieldOffset(0)]
			public CHAR_UNION Char;

			[FieldOffset(2)]
			public short Attributes;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct SMALL_RECT
		{
			public short Left;
			public short Top;
			public short Right;
			public short Bottom;

			public SMALL_RECT(short left, short top, short right, short bottom)
			{
				Left = left;
				Top = top;
				Right = right;
				Bottom = bottom;
			}

			public SMALL_RECT(int left, int top, int right, int bottom)
			{
				Left = (short)left;
				Top = (short)top;
				Right = (short)right;
				Bottom = (short)bottom;
			}
		}
	}
}