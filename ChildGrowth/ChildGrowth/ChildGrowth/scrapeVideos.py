import urllib
from urllib import urlopen
import re
from bs4 import BeautifulSoup

path = "C:\Users\kevjy\Documents\childgrowth\ChildGrowth\ChildGrowth\ChildGrowth\data"
url = "https://www.cdc.gov/ncbddd/actearly/milestones/milestones-3yr.html"
content = urllib.urlopen(url).read()
soup=BeautifulSoup(content,"html.parser")

# print soup
html = soup.find_all(href=re.compile(".youtube*"))

for i in range(0,len(html)):
    print html[i]['href']