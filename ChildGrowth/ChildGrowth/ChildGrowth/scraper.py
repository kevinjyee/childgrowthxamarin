import pandas as pd

def readInCSV():
    df = pd.read_csv("data/wtageinf.csv");
    print df.loc[df['Sex'] == 2, 'Agemos'].tolist();

if __name__ == "__main__":
  readInCSV()