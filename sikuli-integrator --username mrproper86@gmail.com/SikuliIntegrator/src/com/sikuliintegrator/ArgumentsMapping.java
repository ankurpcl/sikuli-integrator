package com.sikuliintegrator;

import java.io.File;
import java.io.FileNotFoundException;

public class ArgumentsMapping
{
  private String patternURL;
  private double similarity;
  private int timeout;

  public ArgumentsMapping(String[] args)
  {
    setPatternURL(args[Arguments.PATTERN_URL.ordinal()]);
    setSimilarity(Double.valueOf(args[Arguments.SIMILARITY.ordinal()]).doubleValue());
    setTimeout(Integer.valueOf(Arguments.TIMEOUT.ordinal()).intValue());
  }

  public String getPatternURL() throws FileNotFoundException {
    File file = new File(this.patternURL);
    if (!file.exists())
    {
      throw new FileNotFoundException();
    }

    return this.patternURL;
  }
  public void setPatternURL(String patternURL) {
    this.patternURL = patternURL;
  }

  public double getSimilarity() {
    return this.similarity;
  }

  public void setSimilarity(double similarity) {
    this.similarity = similarity;
  }

  public int getTimeout() {
    return this.timeout;
  }

  public void setTimeout(int timeout) {
    this.timeout = timeout;
  }
}
