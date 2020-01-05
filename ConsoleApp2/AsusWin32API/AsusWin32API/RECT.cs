// Decompiled with JetBrains decompiler
// Type: AsusWin32API.RECT
// Assembly: AsusWin32API, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: FF5A172A-B9F1-40B4-A5E7-ECA21938E9F1
// Assembly location: C:\Program Files (x86)\ASUSTeK COMPUTER INC\ROG Gaming Center\AsusWin32API.dll

using System;
using System.Runtime.InteropServices;

namespace AsusWin32API
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct RECT
  {
    public int left;
    public int top;
    public int right;
    public int bottom;
    public static readonly RECT Empty;

    public int Width
    {
      get
      {
        return Math.Abs(this.right - this.left);
      }
    }

    public int Height
    {
      get
      {
        return this.bottom - this.top;
      }
    }

    public RECT(int left, int top, int right, int bottom)
    {
      this.left = left;
      this.top = top;
      this.right = right;
      this.bottom = bottom;
    }

    public RECT(RECT rcSrc)
    {
      this.left = rcSrc.left;
      this.top = rcSrc.top;
      this.right = rcSrc.right;
      this.bottom = rcSrc.bottom;
    }

    public bool IsEmpty
    {
      get
      {
        if (this.left < this.right)
          return this.top >= this.bottom;
        return true;
      }
    }

    public override string ToString()
    {
      if (this == RECT.Empty)
        return "RECT {Empty}";
      return "RECT { left : " + (object) this.left + " / top : " + (object) this.top + " / right : " + (object) this.right + " / bottom : " + (object) this.bottom + " }";
    }

    public override bool Equals(object obj)
    {
      if (!(obj is RECT))
        return false;
      return this == (RECT) obj;
    }

    public override int GetHashCode()
    {
      return this.left.GetHashCode() + this.top.GetHashCode() + this.right.GetHashCode() + this.bottom.GetHashCode();
    }

    public static bool operator ==(RECT rect1, RECT rect2)
    {
      if (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right)
        return rect1.bottom == rect2.bottom;
      return false;
    }

    public static bool operator !=(RECT rect1, RECT rect2)
    {
      return !(rect1 == rect2);
    }
  }
}
