package com.sikuliintegrator;

import java.io.FileNotFoundException;

import org.sikuli.script.Match;
import org.sikuli.script.Screen;
import org.sikuli.script.Settings;

public class Pointer
{
  public static void main(String[] args)
  {
    int status = 1;
    try
    {
      if (args.length == Constants.ARGUMENTS_COUNT)
      {
        ArgumentsMapping arguments = new ArgumentsMapping(args);

        Screen screen = new Screen();

        Settings.InfoLogs = false;
        Settings.DebugLogs = false;
        Settings.ProfileLogs = false;
        Settings.ActionLogs = false;

        org.sikuli.script.Settings.MinSimilarity = arguments.getSimilarity();

        Match match = screen.exists(arguments.getPatternURL(), arguments.getTimeout());

        if (match != null)
        {
          System.out.println("###(" + match.getCenter().x + ";" + match.getCenter().y + ")");
          match.highlight();
          status = 0;
        }
        else
        {
          System.out.println("###1:There is no matching element");
        }
      }
      else
      {
        System.out.println("###2:The number of arguments is not correct");
      }
    }
    catch (FileNotFoundException ex)
    {
      System.out.println("###3:Pattern file can not be found");
    }
    System.exit(status);
  }
}
