# EduQuiz_Question_Answering_System

#### FYI:

![data-collection example](images_FYI/data-collection_example.png)

------



### Questions:

1. Document(2 fields)? 1st field-text , 2nd filed-url? // **one field, url+text!**
2. Is it user allowed to choose any indexing strategy?
3. Where should we use the 'query', 'answer'?
4. Does the baseline system need to "pre-process" the query?
5. How to implement the feature of "highlighting set of matching passage text for the query"?

------

#### Step1: Create baseline system

- For each passage in the collection, all of the text and url is indexed as a single field. 
- The Analyzer used during index and search is the **Lucene.Net.Analysis.Simple analyzer**. 
- The index does not save information related to field normalisation. 
- The index does not save information related to term vectors. 





#### 1. Task 1 — **Index**:

**mockup: Indexing Strategy** is not settled down, just put it there for now

![Task1-Index](images_mockups/Task1-Index.png)



**implemention: Indexing Strategy**

![Task1-Index](images_implementation/Task1-Index.png)







------

#### Progress1: Successfully indexed, and show result of searching 'RBA'—which is a query test;

![Task1&2_Test](images_implementation/Task1&2_Test.png)

It is able to open the JSON file based on user browsing, and specify a indexing folder based on user browsing. Put a hard coded query of 'RBA' to search for the results, the results are just simply displayed at the bottom of the Indexing Page.

------





#### 2. Task2 — Search:

**mockup:**

![Task2-Search](images_mockups/Task2-Search.png)

------

#### Progress 2: 

###### 1)display index time  

###### 2) add button to redirect to searching page  

###### 3) simple searching page implementation



![Progress2_1](images_implementation/Progress2_1.png)





![Progress2_2](images_implementation/Progress2_2.png)

