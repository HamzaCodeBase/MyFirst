using System.Runtime.InteropServices;

namespace DllImport_LibraryImport
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var task1 = Task.Run(() => WinApiOld.MessageBox(IntPtr.Zero, "Hello from DllImport", "DllImport Demo", 0));

            var task2 = Task.Run(() => WinApiNew.MessageBox(IntPtr.Zero, "سلام", "👋", 0));

            await Task.WhenAll(task1, task2);
        }
    }

    public static class WinApiOld
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    }

    public static partial class WinApiNew
    {
        // New Source-Generated P/Invoke (requires .NET 7+)
        [LibraryImport("user32.dll", EntryPoint = "MessageBoxW", StringMarshalling = StringMarshalling.Utf16)]
        public static partial int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    }
}

/*
──────────────────────────────────────────────────────────────
📌 Windows API + P/Invoke + Native AOT Notes
──────────────────────────────────────────────────────────────

🔹 Windows API String Handling Rule
-----------------------------------
• Any Win32 function that uses string parameters is exported twice:
  → FunctionNameA = ANSI (8-bit chars)
  → FunctionNameW = Unicode UTF-16 (2 bytes per char)
• There is usually NO export named simply FunctionName.

✅ Always prefer the W (Unicode) version for modern Windows.

Examples:
 MessageBoxA  // ANSI
 MessageBoxW  // UTF-16 Unicode  ✅ Best choice

Functions without string parameters (e.g., Sleep, Beep) have no A/W suffix.

──────────────────────────────────────────────────────────────
🔹 DllImport vs LibraryImport Behavior
-------------------------------------

DllImport (Classic Runtime P/Invoke):
✅ Auto-fallback name search:
   1. "MessageBox"
   2. If Unicode -> "MessageBoxW"
   3. If ANSI   -> "MessageBoxA"
✅ Works even if you don't specify EntryPoint
⚠️ Runtime code generation → not ideal for Native AOT

LibraryImport (Source Generated + Native AOT):
❌ NO fallback for A/W names
❌ Must match exact symbol name in DLL
✅ Faster + AOT supported
✅ Compile-time marshalling generation
⚠️ Often requires unsafe code

──────────────────────────────────────────────────────────────
🔹 StringMarshalling Settings
-------------------------------------
Controls how C# strings convert to native format:

 StringMarshalling.Utf16 → Use with W (Unicode) functions ✅
 StringMarshalling.Utf8  → Rarely used for classic WinAPI
 StringMarshalling.Custom → Manual handling

✅ Best practice for WinAPI:
   Use "W" EntryPoint + Utf16 marshalling

──────────────────────────────────────────────────────────────
✅ Recommended Template for WinAPI using LibraryImport (.NET 7+)

[LibraryImport("user32.dll", EntryPoint = "MessageBoxW",
               StringMarshalling = StringMarshalling.Utf16)]
internal static partial int MessageBox(IntPtr hWnd,
                                      string text,
                                      string caption,
                                      uint type);

──────────────────────────────────────────────────────────────
Summary:
→ Windows APIs with strings = A/W versions exist
→ DllImport auto-detects → works without suffix
→ LibraryImport requires exact EntryPoint and marshalling
──────────────────────────────────────────────────────────────
*/

