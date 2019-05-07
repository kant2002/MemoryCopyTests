﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryCopyTests
{
    public class HtmlToPlain
    {
        //public static string HtmlAgility(string input)
        //{
        //    var doc = new HtmlAgilityPack.HtmlDocument();
        //    doc.LoadHtml(input);
        //    doc.DocumentNode.Descendants()
        //        .Where(n => n.Name == "script" || n.Name == "style")
        //        .ToList()
        //        .ForEach(n => n.Remove());

        //    var root = doc.DocumentNode;
        //    var sb = new StringBuilder();
        //    var nodes =
        //    (
        //        from n in root.DescendantsAndSelf()
        //        where !n.HasChildNodes
        //        let txt = n.InnerText?.Trim()
        //        where !txt.IsNullOrEmpty()
        //        select txt
        //    ).ToList();

        //    nodes.ForEach(t => sb.AppendLine(HttpUtility.HtmlDecode(t)));

        //    var result = sb.ToString();
        //    if (result.IsNullOrEmpty())
        //        return null;

        //    return result;
        //}

        public static string CharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (inside && let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public unsafe static string CharArrayPointer(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            fixed (char* p = source)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    char* let = p + i;
                    if (*let == '<')
                    {
                        inside = true;
                        continue;
                    }

                    if (inside && *let == '>')
                    {
                        inside = false;
                        continue;
                    }

                    if (!inside)
                    {
                        array[arrayIndex] = *let;
                        arrayIndex++;
                    }
                }
            }
            return new string(array, 0, arrayIndex);
        }

        unsafe static int IndexOf(char* p, char c, int start, int maxLen)
        {
            var i = start;
            while (i < maxLen)
            {
                if (*(p + i) == c)
                    return i;
                i++;
            }

            return -1;
        }

        public unsafe static string CharArrayPointerBuffer(string source)
        {
            var arrayIndex = 0;
            var maxLen = source.Length;
            var dest = new char[maxLen];
            var i = 0;

            fixed (char* p = source)
            {
                fixed (char* d = dest)
                {
                    do
                    {
                        var index = IndexOf(p, '<', i, maxLen);
                        if (index < 0)
                        {
                            Buffer.MemoryCopy(p + i, d + arrayIndex, sizeof(char) * (maxLen - arrayIndex), sizeof(char) * (maxLen - i));
                            arrayIndex += maxLen - i;
                            break;
                        }
                        Buffer.MemoryCopy(p + i, d + arrayIndex, sizeof(char) * (maxLen - arrayIndex), sizeof(char) * (index - i));
                        arrayIndex += index - i;

                        i = IndexOf(p, '>', index, maxLen) + 1;
                    }
                    while (i < source.Length && i > 0);
                }
            }

            return new string(dest, 0, arrayIndex);
        }

        public unsafe static string CharArrayPointerBufferWithStackAllock(string source)
        {
            var arrayIndex = 0;
            var maxLen = source.Length;
            var d = stackalloc char[maxLen];
            var i = 0;

            fixed (char* p = source)
            {
                do
                {
                    var index = IndexOf(p, '<', i, maxLen);
                    if (index < 0)
                    {
                        Buffer.MemoryCopy(p + i, d + arrayIndex, sizeof(char) * (maxLen - arrayIndex), sizeof(char) * (maxLen - i));
                        arrayIndex += maxLen - i;
                        break;
                    }
                    Buffer.MemoryCopy(p + i, d + arrayIndex, sizeof(char) * (maxLen - arrayIndex), sizeof(char) * (index - i));
                    arrayIndex += index - i;

                    i = IndexOf(p, '>', index, maxLen) + 1;
                }
                while (i < source.Length && i > 0);
            }

            return new string(d, 0, arrayIndex);
        }

        public static string CharArrayStringIndexOf(string source)
        {
            var arrayIndex = 0;
            var maxLen = source.Length;
            var dest = new char[maxLen];
            var i = 0;

            var sourceChars = source.ToCharArray();
            do
            {
                var index = source.IndexOf('<', i);
                if (index < 0)
                {
                    Array.Copy(sourceChars, i, dest, arrayIndex, maxLen - i);
                    arrayIndex += maxLen - i;
                    break;
                }
                Array.Copy(sourceChars, i, dest, arrayIndex, index - i);
                arrayIndex += index - i;

                i = source.IndexOf('>', index) + 1;
            }
            while (i < maxLen && i > 0);

            return new string(dest, 0, arrayIndex);
        }

        public static string StringBuilder(string source)
        {
            var result = new StringBuilder();
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }

                if (inside && let == '>')
                {
                    inside = false;
                    continue;
                }

                if (!inside)
                    result.Append(let);
            }

            return result.ToString();
        }

        public static string StringBuilderStringIndexOf(string source)
        {
            var result = new StringBuilder();
            var i = 0;

            do
            {
                var index = source.IndexOf('<', i);
                if (index < 0)
                {
                    result.Append(source.Substring(i));
                    break;
                }
                result.Append(source.Substring(i, index - i));
                i = source.IndexOf('>', index) + 1;
            }
            while (i < source.Length && i > 0);

            return result.ToString();
        }

        public static string StringJoinStringIndexOf(string source)
        {
            var result = new List<string>();
            var i = 0;

            do
            {
                var index = source.IndexOf('<', i);
                if (index < 0)
                {
                    result.Add(source.Substring(i));
                    break;
                }
                result.Add(source.Substring(i, index - i));
                i = source.IndexOf('>', index) + 1;
            }
            while (i < source.Length && i > 0);

            return string.Join(String.Empty, result);
        }

        public static string StringBuilderRemoveStringIndexOf(string source)
        {
            var result = new StringBuilder(source);
            var i = 0;
            var lenDeleted = 0;
            do
            {
                var index = source.IndexOf('<', i);
                if (index < 0)
                    break;

                i = source.IndexOf('>', index);
                if (i < 0)
                {
                    result.Remove(index - lenDeleted, source.Length - index);
                    break;
                }
                i += 1;

                result.Remove(index - lenDeleted, i - index);
                lenDeleted += i - index;
            }
            while (i < source.Length);

            return result.ToString();
        }
    }

}
