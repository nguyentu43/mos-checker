using GUI.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Db
    {
        public static void initDb()
        {
            //Office 2013

            //Test 1
            Test test_1_office_2013 = new Test()
            {
                Name = "Test 1",
                OfficeApp = "Word",
                OfficeVersion = "Office 2013",
                Resources = new List<string>()
                {
                    "Newsletter.docm"
                }
            };
            test_1_office_2013.Questions = new List<Question>()
            {
                new Question()
                {
                    Title = "Theme",
                    Index = 1,
                    Content = "<div class='titleRow'>Apply a <b>theme</b> to document</div><div class='posRow'>Entire document</div><div class='listRow'>* Theme: <b>Ion</b></div>",
                    Group = "1-Newsletter",
                    Help = "1. In the DESIGN tab, Document Formatting group, select the Theme drop-down.\n2. Select Ion."
                },
                new Question()
                {
                    Title = "Background Color",
                    Index = 2,
                    Content = "<div class='titleRow'>Change the background color.</div><div class='posRow'>Entire document</div><div class='listRow'><b>Blue-Gray, Accent 5, Lighter 60%</div>",
                    Group = "1-Newsletter",
                    Help = "1. In the DESIGN tab, Page Background group, select Page Color.\n2. Select Blue-Gray, Accent 5, Lighter 60%."
                },
                new Question()
                {
                    Title = "Page Border",
                    Index = 3,
                    Content = "<div class='titleRow'>Add a <b>page border</b> to a document.</div><div class='posRow'>Entire document</div><div class='listRow'>* <b>Box</b><br>* Accept all defaults</div>",
                    Group = "1-Newsletter",
                    Help = @"1. In the DESIGN tab, Page Background group, select Page Borders.
2. In the Page Borders tab, under Settings, select Box.
3. Click OK."
                },
                new Question()
                {
                    Title = "Breaks",
                    Index = 4,
                    Content = "<div class='titleRow'>Add breaks to separate portions of a document.</div><div class='posRow'>First page, fifth paragraph. At the beginning of the line, <b>For each toxin…</b></div><div class='listRow'>* <b>Section Break (Continuous)</b></div><div class='posRow'>Third page, third paragraph. At the beginning of the line, <b>Question: I have a serious pain…</b></div><div class='listRow'>* <b>Section Break (Continuous)</b></div><div class='posRow'>Third page, at the beginning of the heading <b>Question and Answer with Dr. Nelson</b></div><div class='listRow'>* <b>Page Break</b></div>",
                    Group = "1-Newsletter",
                    Help = @"I.
1. On the first page, fifth paragraph, click to the left of the first letter in the phrase, For each toxin...
2. In the PAGE LAYOUT tab, Page Setup group, select the Breaks drop-down.
3. Select Continuous.

II.
1. On the third page, third paragraph, click to the left of the first letter in the sentence, Question: I have a serious pain…
2. In the PAGE LAYOUT tab, Page Setup group, select the drop down for Breaks.
3. Select Continuous.

III.
1. On the third page, click to the left of the phrase, Question and Answer with Dr. Nelson.
2. In the PAGE LAYOUT tab, Page Setup group, select the Breaks drop- down.
3. Select Page Break."
                },
                new Question()
                {
                    Title = "Orientation",
                    Index = 5,
                    Content = "<div class='titleRow'>Change the <b>orientaton</b> of specific pages.</div><div class='posRow'>First page only</div><div class='listRow'>* <b>Landscape</b> (Note: All other pages are to remain in <b>Portrait</b> orientation)</div>",
                    Group = "2-Page 1",
                    Help = @"1. Position your cursor near the top of the first page. (Hint: Anywhere above the Section Break)
2. In the PAGE LAYOUT tab, Page Setup group, select the Orientation drop-down.
3. Select Landscape.
(Hint: All except the first page of the document should remain in Portrait orientation. If not, reinsert your breaks in the previous tasks above)."
                },
                new Question()
                {
                    Title = "Bulleted List",
                    Index = 6,
                    Content = "<div class='titleRow'>Create a bulleted list from a selection of text.</div><div class='posRow'>First page, fourth paragraph, <b>Dry mouth</b> through <b>Addictive personality.</b></div><div class='listRow'>* <b>Checkmarks</b><br>* <b>Indentation \"0.5\" </b>(1.27 cm)<br> * 3 <b>columns</b></div>",
                    Group = "2-Page 1",
                    Help = @"1. On the first page, fourth paragraph, select the text from Dry mouth to Addictive personality.
2. In the HOME tab, Paragraph group, select the Bullets drop-down.
3. Select Check Marks.
4. Click the dialogue box launcher in the lower-right corner of the Paragraph group.
5. Under Indentation, for Left, either navigate to, or type in, ""0.5""(1.27 cm)
6. Click OK.
7. Select the bulleted list, from Dry mouth to Addictive personality.
8. In the PAGE LAYOUT tab, Page Setup group, select the Columns drop-down.
9. Select Three."
                },
                new Question()
                {
                    Title = "Insert Image",
                    Index = 7,
                    Content = "<div class='titleRow'>Add images to a document.</div><div class='posRow'>First page, upper right corner.</div><div class='listRow'>* <b>doctor.png</b><br>* Position: <b>Top Riht with Square Text Wrapping</b><br>* Picture Style: <b>Thick Matte, Black</b></div>",
                    Group = "2-Page 1",
                    Help = @"1. Place your cursor at the beginning of the document.
2. In the INSERT tab, Illustrations group, click Pictures.
3. Browse to your GMetrixTemplates folder, select the image doctor.png.
4. Click Insert.
5. Select the image. In the PICTURE TOOLS/FORMAT tab, Arrange group, select the Position drop-down.
6. Click Position in Top Right with Square Text Wrapping.
7. In the Picture Styles group, select the More drop-down arrow to open the Picture Styles gallery.
8. Select Thick Matte, Black."
                },
                new Question()
                {
                    Title = "Shapes",
                    Index = 8,
                    Content = "<div class='titleRow'>Insert a shape into the document.</div><div class='posRow'>In the empty space on the first page.</div><div class='listRow'>* <b>Simley Face</b><br>* Style: <b>Colored Outline - Black, Dark 1</b></div>",
                    Group = "2-Page 1",
                    Help = @"1. Place your cursor below the text on the first page.
2. In the INSERT tab, Illustrations group, select the drop down for Shapes.
3. In the Basic Shapes section, select Smiley Face.
4. Click and drag in the empty space to create the shape. Note - actual size, shape and positioning does not matter.
5. In the DRAWING TOOLS/FORMAT tab, Shape Styles group, click the More drop-down arrow to open the Shape Styles gallery.
6. Select Colored Outline - Black, Dark 1."
                },
                new Question()
                {
                    Title = "Caption",
                    Index = 9,
                    Content = "<div class='titleRow'>Insert a caption under the shape.</div><div class='posRow'>Under the <b>Smiley Face</b> shape</div><div class='listRow'>* Figure caption <br>* Position below shape<br>* Text: <b>\"When you aren't toxic, you are happy!\"</b><br>* <b>Exclude label from caption</b<br>* Drag to center below shape</div>",
                    Group = "2-Page 1",
                    Help = @"1. On the first page, right-click on the Smiley Face.
2. Select Insert Caption.
3. Under Caption: type ""When you aren't toxic, you are happy!""
4. For Label: select Figure.
5. For Position: select Below selected item.
6. Select the check box for Exclude label from caption.
7.Click OK.
8.Use the resize handles on the caption box to center the caption below the shape.",
                },
                new Question()
                {
                    Title = "Table",
                    Index = 10,
                    Content = "<div class='titleRow'>Convert text to a table.</div><div class='posRow'>Second page, below the first paragraph. beginning with, <b>Toxin</b> through <b>Some Nausea.</b></div><div class='listRow'>* 4 <b>Columns</b><br>* Separate at tabs</div>",
                    Group = "3-Page 2",
                    Help = @"1. On the second page, below the first paragraph, select the text from Toxin to Some Nausea located below the paragraph that starts with the sentence, For each toxin...
2. In the INSERT tab, Tables group, select the Table drop-down.
3. Select Convert Text to Table.
4. Confirm the following settings.
Number of columns: 4
Fixed column width: Auto
Separate text at: Tabs.
5. Click OK."
                },
                new Question()
                {
                    Title = "Modify Table Data",
                    Index = 11,
                    Content = "<div class='titleRow'>Modify Table Data</div><div class='posRow'>Table column 4 <b>(Side Effects)</b>, row 5 (<b>Iron</b>).</div><div class='listRow'>* Delete the text, <b>None</b><br>* Insert the text, <b>\"Constipation\"</b></div>",
                    Group = "3-Page 2",
                    Help = @"1. In the table, under column 4 (Side Effects), in row 5 (Iron) delete the text, None.
2. Type the text, ""Constipation""."
                },
                new Question()
                {
                    Title = "Table Style",
                    Index = 12,
                    Content = "<div class='titleRow'>Apply a style to a table.</div><div class='posRow'>Entire table</div><div class='listRow'>* <b>Grid Table 4 - Accent 4</b></div>",
                    Group = "3-Page 2",
                    Help = @"1. Click on the table to select it.
2. On the TABLE/DESIGN tab, Table Styles group, click the More drop-down to open the Table Styles gallery.
3. Under the Grid Tables section, select Grid Table 4 - Accent 4."
                },
                new Question()
                {
                    Title = "Format Table",
                    Index = 13,
                    Content = "<div class='titleRow'>Add formatting to the table headers.</div><div class='posRow'>Table headers (<b>Toxins</b> to <b>Side Effects</b>)</div><div class='listRow'>* Center align</div>",
                    Group = "3-Page 2",
                    Help = @"1. On the table, select the header row, from Toxins to Side Effects.
2. In the TABLE/LAYOUT tab, Alignment group, select Align Center."
                },
                new Question()
                {
                    Title = "Modify Style",
                    Index = 14,
                    Content = "<div class='titleRow'>Change a style</div><div class='posRow'><b>Intense Emphasis</b> style</div><div class='listRow'>* <b>Black, Text 1, lighter 15%</b><br>* Font size <b>12</b></div>",
                    Group = "3-Page 2",
                    Help = @"1. In the HOME tab, Styles group, select the dialogue box launcher for Styles.
2. Select the drop down for Intense Emphasis. (Hint: Alternately you can right-click Intense Emphasis within the Styles gallery.)
3. Select Modify.
4. In the Modify Style dialogue window, select Format.
5. Select Font.
6. Select the drop down for Font Color.
7. Select Black, Text 1, lighter 15%
8. Under Size select 12.
9. Click OK twice.
10. Close the Styles pane by clicking the X in the upper-right corner."
                },
                new Question()
                {
                    Title = "Apply Style",
                    Index = 15,
                    Content = "<div class='titleRow'>Apply a style to selection of text.</div><div class='posRow'>Second page, the sentence <b>Are You Ok, Sparky?</b></div><div class='listRow'>* Title</div><div class='posRow'>Second page, the sentence <b>What about our pets?</b></div><div class='listRow'>* <b>Intense Emphasis</b></div>",
                    Group = "3-Page 2",
                    Help = @"I.
1. On the second page, about halfway down the page, select the text, Are You Ok, Sparky?
2. In the HOME tab, Styles group, select the Styles drop-down.
3. Select Title.

II.
1. On the second page, just below the title Are You Ok, Sparky?, select the text What about our pets?
2. In the HOME tab, Styles group, select the Styles drop-down.
3. Select Intense Emphasis."
                },
                new Question()
                {
                    Title = "Insert Image",
                    Index = 16,
                    Content = "<div class='titleRow'>Add images to a document.</div><div class='posRow'>Second page, below the subheading, <b>What about our pets?</b></div><div class='listRow'>* <b>kitty.jpg</b><br>* Height: \"<b>50</b>\" percent<br>* Width: \"<b>50</b>\" percent<br>* <b>Tight wrap</b><br><b>Bevel Divot</b> style</div>",
                    Group = "3-Page 2",
                    Help = @"1. On the second page, position your cursor under the subheading, What about our pets?
2. In the INSERT tab, Illustrations group, select Pictures.
3. Browse to your GMetrixTemplates folder, select the image kitty.jpg.
4. Click Insert.
5. In the PICTURE TOOLS/FORMAT tab, Size group, select the dialogue box launcher for Size.
6. Under Scale, for both Height and Width, type or navigate to ""50%"". Click OK.
7. In the Arrange group, select the Wrap Text drop-down.
8. Click Tight.
9. In the Picture Styles group, click the Picture Effects drop-down.
10. Select Bevel, then click Divot."
                },
                new Question()
                {
                    Title = "WordArt",
                    Index = 17,
                    Content = "<div class='titleRow'>Convert select text to <b>WordArt</b></div><div class='posRow'>Second page, the letter <b>A</b> in the heading, <b>Are You Ok, Sparky?</b></div><div class='listRow'>* <b>WordArt</b> Style: <b>Fill - Black, Text 1, Outline - Background 1, Hard Shadow -Background 1</b></div>",
                    Group = "3-Page 2",
                    Help = @"1. On the second page, select the letter A in Are You Ok, Sparky?
2. In the INSERT tab, Text group, select the drop-down for WordArt.
3. Select Fill - Black, Text 1, Outline - Background 1, Hard Shadow -Background 1."
                },
                new Question()
                {
                    Title = "Text Formatting",
                    Index = 18,
                    Content = "<div class='titleRow'>Add direct formatting to a selection of text.</div><div class='posRow'>Third page, sixth paragraph, the phrase <b>lukewarm water.</b></div><div class='listRow'>* <b>Double Underline</b></div>",
                    Group = "4-Page 3",
                    Help = @"1. On the third page, sixth paragraph, select the phrase lukewarm water.
2. In the HOME tab, Font group, click the drop-down for Underline [U]
3. Select Double underline."
                },
                new Question()
                {
                    Title = "Apply Style",
                    Index = 19,
                    Content = "<div class='titleRow'>Apply Style</div><div class='posRow'>Last page, the sentence <b>Question and Answer with Doctor Nelson.</b></div><div class='listRow'>* <b>Heading 1</b></div>",
                    Group = "5-Page 4",
                    Help = @"1. On the last page, select Question and Answer with Doctor Nelson.
2. In the HOME tab, Styles group, select the drop down for Styles.
3. Select Heading 1."
                },
                new Question()
                {
                    Title = "Margins",
                    Index = 20,
                    Content = "<div class='titleRow'>Change the margins of specific pages.</div><div class='posRow'>Last page, beginning with <b>Question: I have a…</b> through <b>…questions to Dr. Nelson.</b></div><div class='listRow'>* Wide Margins</div>",
                    Group = "5-Page 4",
                    Help = @"1. On the last page, select the text beginning with, Question: I have a ... through …questions to Doctor Nelson.
2. In the PAGE LAYOUT tab, Page Setup group, select the Margins drop-down.
3. Select Wide."
                },
                new Question()
                {
                    Title = "Footnote",
                    Index = 21,
                    Content = "<div class='titleRow'>Add a <b>footnote</b> to the document.</div><div class='posRow'>In the heading on the last page, associate the <b>footnote</b> to the text, <b>Dr. Nelson.</b></div><div class='listRow'>* Footnote text: Cut and paste the paragraph beginning with <b>Dr. William Nelson...</b> to <b>... a recreational vehicle.</b></div>",
                    Group = "5-Page 4",
                    Help = @"1. On the last page, select Dr. Nelson in the heading Question and Answer with Dr. Nelson.
2. In the REFERENCE tab, Footnotes group, select Insert Footnote.
3. In the paragraph below the heading, Question and Answer with Dr. Nelson, cut the text Dr. William Nelson... to ...a recreational vehicle.
4. Paste the text in the footnote at the bottom of the page."
                },
                new Question()
                {
                    Title = "Hyperlink",
                    Index = 22,
                    Content = "<div class='titleRow'>Add a <b>hyperlink</b> to selected text.</div><div class='posRow'>Last paragraph, <b>hyperlink</b> the text <b>email all of your questions.</b></div><div class='listRow'>* Link to: \"<b>williamnelson@hypotheticaluniversity.com</b>\"</div>",
                    Group = "5-Page 4",
                    Help = @"1. In the last paragraph, select the text, email all of your questions.
2. In the INSERT tab, Links group, select Hyperlink.
3. Under Link to: select E-mail address.
4. Under E-mail address, type ""williamnelson@hypotheticaluniversity.com""
5. Click OK."
                },
                new Question()
                {
                    Title = "Macro",
                    Index = 23,
                    Content = "<div class='titleRow'>Create a <b>macro.</b></div><div class='posRow'>Store the <b>macro</b> in the current document</div><div class='listRow'>* Name the macro, \"<b>Emphasis</b>\"<br>* Actions: <b>Bold, Underline</b></div>",
                    Group = "6-Final Steps",
                    Help = @"1. In the VIEW tab, Macros group, select the Macros drop-down.
2. Select Record Macro.
3. In the field Macro name: type ""Emphasis"".
4. Select the drop-down for Store macro in: and select Newsletter(document).
Note: If you have saved and resumed your test, the document name will have changed.Select the option that ends with the word(document).
5.Accept all other defaults and click OK.
6.In the HOME tab, Font group, select the Bold button(B).
7.In the HOME tab, Font group, select the Underline button(U).
8.In the VIEW tab, Macros group, select the drop - down for Macros.
 9.Select Stop Recording."
                },
                new Question()
                {
                    Title = "Navigate",
                    Index = 24,
                    Content = "<div class='titleRow'>Use the <b>Navigation pane.</b></div><div class='posRow'>Find all instances of <b>Toxins</b> in the document</div><div class='listRow'>* Apply the <b>Emphasis</b> macro</div>",
                    Group = "6-Final Steps",
                    Help = @"1. In the HOME tab, Editing group, select Find.
2. In the Navigation pane, type ""Toxins"".
3. Five instances of Toxins should be hightlighted in the document. Hold down the CTRL key and select all five instances of Toxins
in the document.

4. In the VIEW tab, Macros group, select View Macros.
5. Select Emphasis and click Run.
(Hint: All five instances of Toxins should become bold and underlined.)
6. Click the X in the upper-right corner of the Navigation pane to close it."
                },
                new Question()
                {
                    Title = "Quick Parts",
                    Index = 25,
                    Content = "<div class='titleRow'>Use <b>Quick Parts</b> to insert a <b>Publish Date.</b></div><div class='posRow'>End of last page</div><div class='listRow'>* <b>Publish Date</b></div>",
                    Group = "6-Final Steps",
                    Help = @"1. Place your cursor at the end of the last page of the document.
2. In the INSERT tab, Text group, select the drop down for Quick Parts.
3. Hover over Document Property.
4. Select Publish Date"
                },
                new Question()
                {
                    Title = "Page Numbers",
                    Index = 26,
                    Content = "<div class='titleRow'>Insert page numbering.</div><div class='posRow'>Bottom of Page</div><div class='listRow'>* <b>Ribbon</b> (under <b>With Shapes</b> section)</div>",
                    Group = "6-Final Steps",
                    Help = @"1. In the INSERT tab, Header and Footer group, select the Page Numbers drop-down.
2. Hover over Bottom of Page.
3. Scroll to the section, With Shapes, and select Ribbon."
                },
                new Question()
                {
                    Title = "Document Property",
                    Index = 27,
                    Content = "<div class='titleRow'>Add values to document property fields.</div><div class='posRow'>Title</div><div class='listRow'>* <b>Health Newsletter</b></div>",
                    Group = "6-Final Steps",
                    Help = @"1. In the FILE tab, on the right side of the Info page, under Properties, locate the Title field.
2. To the right of Title, click on Add a Title.
3. Type ""Health Newsletter""."
                },
                new Question()
                {
                    Title = "Restrict Editing",
                    Index = 28,
                    Content = "<div class='titleRow'>Limit editing in this document</div><div class='posRow'><b>Allow only this type of editing in the document</b></div><div class='listRow'>* Tracked Changes<br>* Password: \"<b>GMetrix</b>\"</div>",
                    Group = "6-Final Steps",
                    Help = @"1. In the REVIEW tab, Protect group, select Restrict Editing.
2. Under Editing Restrictions: check the box that says: Allow only this type of editing in the document:
3. Select the drop down under the check box.
4. Select Tracked Changes.
5. Click Yes, Start Enforcing Protection.
6. Type ""GMetrix"" twice. Click OK."
                },
                new Question()
                {
                    Title = "Document Options",
                    Index = 29,
                    Content = "<div class='titleRow'>Change document options.</div><div class='posRow'>Display options</div><div class='listRow'>* Enable: <b>Print document properties</b></div><div class='posRow'>Proofing options</div><div class='listRow'>* Disable: <b>Check spelling as you type</b></div><div class='posRow'>Advanced Options</div><div class='listRow'>* <b>Allow Open in Draft View</b></div>",
                    Group = "6-Final Steps",
                    Help = @"I.
1. In the FILE tab, select Options.
2. In the Display tab, under Printing Options, click to put a check mark next to Print document properties.
3. Click OK.

II.
1. In the FILE tab, select Options.
2. In the Proofing tab, under When correcting grammar and spelling in Word click so there is not a check mark next to Check spelling as you type.
3. Click OK.

III.
1. In the FILE tab, select Options.
2. In the Advanced tab, under the General section, check the box next to Allow opening a document in Draft View
3. Click OK

Note: If you do not close the Word Options menu before grading your test it will cause an issue with scoring."
                },
            };

            Test test_1_office_2016 = new Test()
            {
                OfficeApp = "Word",
                OfficeVersion = "Office 2016",
                Name = "Test 1",
                Resources = new List<string>()
                {
                    "Bicycles.docx", "Networking.docx", "IceCream.docx", "RockCrawling.docx",
                    "Fishing.docx", "FusionTomo.docx", "Scuba.docx"
                }
            };

            List<Question> questions = new List<Question>()
            {
                new Question()
                {
                    Title = "OVERVIEW",
                    Content = @"<h2>Bicycles</h2>
The bicycle sales and rental store Bellows Bicycle Barn has asked you to update their summer sales flier to help attract new customers.",
                    Index = 0,
                    Group = "1"
                },
                new Question()
                {
                    Title = "TASK 1",
                    Content = @"On <b>page 2</b> between the sections <b>Affordable Pricing</b> and <b>Contact Us</b>, insert the file <b>Bicycle_Pricing.xlsx</b> located in the <b>GmetrixTemplates</b> folder. (Accept all defaults)",
                    Index = 1,
                    Group = "1",
                    Help = @"1.	On Page 2, place your cursor in the empty space between the sections Affordable Pricing and Contact Us. 
2.	Click the INSERT tab.
3.	In the Text group, click Object and select Object ...
4.	In the Object pop-up window, click the Create from File tab.
5.	On the Create from File tab, click the Browse button.
6.	Browse to the GMetrixTemplates folder and select Bicycle_Pricing.xlsx and click Insert.
In the Object pop-up window, click OK."
                },
                new Question()
                {
                    Title = "TASK 2",
                    Content = @"Hyperlink the header <b>Bicycle Advantages</b> on <b>page 1</b> to the web page http://wikipedia.org/wiki/Bicycle.",
                    Index = 2,
                    Group = "1",
                    Help = @"1. In the middle of page 1, select the header text ""Bicycle Advantages""
2. In the INSERT tab, in the Links group, click Hyperlink.
3. In the Insert Hyperlink pop-up box, change the following: Link to: Existing File or Web Page Address:http://wikipedia.org/wiki/Bicycle
            4.Click OK. (Hint: If you have an Internet connection, you can test your link by holding your CTRL key while clicking your mouse to follow the link.)"
                },
                new Question()
                {
                    Title = "TASK 3",
                    Content = @"Insert a <b>Continuous Section Break</b> on <b>page 2</b> just before the heading <b>Affordable Pricing.</b>",
                    Index = 3,
                    Group = "1",
                    Help = @"1. On page 2, place your cursor to the left of the heading Affordable Pricing.
2. Click the LAYOUT tab.
3. In the Page Setup group, click Breaks.
4. Below Section Breaks, click Continuous.
(Hint: You can check to see if the break has been added by going to the HOME tab, Paragraph group and clicking the Show/Hide button and then looking for Section Break (Continuous) at the bottom of page 1.)"
                },
                new Question()
                {
                    Title = "TASK 4",
                    Content = @"In the first list, replace the bullets for all of the points below the <b>Bicycle Advantages</b> heading with the graphic <b>Bike Rider.png</b> located in the <b>GMetrixTemplates</b> folder.",
                    Index = 4,
                    Group = "1",
                    Help = @"1. Select all of the text below the heading Bicycle Advantages, beginning with the text Low maintenance...and ending with store.
2. On the HOME tab, in the Paragraph group, click the Bullets down-arrow and select Define New Bullet…
3. In the Define New Bullet pop-up box, under Bullet character, click Picture…
4. In the Insert Pictures pop-up box, to the right of From a file, click Browse and locate the GMetrixTemplates folder. Select the file, Bike Rider.png and click Insert. Notice the sample of the new bullet displayed in the Preview window.
5. On the Define New Bullet pop-up box, click OK."
                },
                new Question()
                {
                    Title = "TASK 5",
                    Content = @"Apply the <b>Soft Edge Rectangle</b> style to the photo at the bottom of page 1.",
                    Index = 5,
                    Group = "1",
                    Help = @"1. At the bottom of Page 1, click on the photo to select it.
2. Select the PICTURE TOOLS FORMAT tab.
3. In the Picture Styles group, select Soft Edge Rectangle."
                },
                new Question()
                {
                    Title = "OVERVIEW",
                    Content = @"<h2>Networking</h2>A school networking club provides fliers about computer networking basics to students. As a member of the club, you have been tasked with preparing a new flier about networking and common network types.",
                    Index = 0,
                    Group = "2"
                },
                new Question()
                {
                    Title = "TASK 1",
                    Content = @"After the <b>last paragraph</b>, insert the text from the file <b>WirelessNetworks.docx</b> located in the <b>GmetrixTemplates</b> folder. (Accept all defaults)",
                    Index = 1,
                    Group = "2",
                    Help = @"1. Place your cursor in the empty space below the last paragraph.
2. Click the INSERT tab.
3. In the Text group, click Object and select Text from File …
4. Browse to the GMetrixTemplates folder and select WirelessNetworks.docx and click Insert."
                },
                new Question()
                {
                    Title = "TASK 2",
                    Content = @"Modify <b>the whole document</b> so the <b>top and bottom margins</b> are <b>1.0""</b> (2.54 cm) and the <b>left and right margins</b> are <b>1.2""</b> (3.048 cm).",
                    Index = 2,
                    Group = "2",
                    Help = @"1. Click the LAYOUT tab.
2. In the Page Setup group, click Margins.
3. At the bottom of the Margins drop-down menu, select Custom Margins …
4. In the Page Setup pop-up window, select the Margins tab, and configure the margins as follows:
Top: 1"" (2.54 cm) Bottom: 1"" (2.54 cm)
Left: 1.2"" (3.048 cm) Right: 1.2""(3.048 cm)
Apply to: Whole document
5.Click OK."
                },
                new Question()
                {
                    Title = "TASK 3",
                    Content = @"Apply the <b>Basic (Elegant)</b> style set to the document.",
                    Index = 3,
                    Group = "2",
                    Help = @"1. Click the DESIGN tab.
2. In the Document Formatting group, click More down-arrow located on the right side of the gallery.
3. Select the Basic (Elegant) style set."
                },
                new Question()
                {
                    Title = "TASK 4",
                    Content = @"Apply a <b>Box border</b> around the <b>entire document</b> that is a <b>solid line, 1 1/2 pt wide, Automatic color.</b> (Accept all other defaults)",
                    Index = 4,
                    Group = "2",
                    Help = @"1. Click the DESIGN tab.
2. In the Page Background group, click Page Borders.
3. On the Borders and Shading pop-up window, ensure the Page Border tab is selected and configure the following:
Setting: Box
Style: Solid Line
Color: Automatic
Width: 1 1/2 pt
Apply to: Whole document
4. Click OK."
                },
                new Question()
                {
                    Title = "TASK 5",
                    Content = @"Insert the <b>networking.jpg</b> photo, located in the <b>GMetrixTemplates</b> folder, to the left of the first paragraph. Apply <b>Tight text wrapping.</b>",
                    Index = 5,
                    Group = "2",
                    Help = @"1. Place your cursor before the first sentence, A computer network...
2. Click the INSERT tab.
3. In the Illustrations group, click Pictures,
4. Browse to the GmetrixTemplates folder and select networking.jpg. Click Insert.
5. To the right of the inserted photo, click the Layout Options icon. Beneath With Text Wrapping click Tight. Accept all other defaults."
                },
                new Question()
                {
                    Title = "OVERVIEW",
                    Content = @"<h2>Ice Cream</h2>
A company you manage sells custom flavored ice cream. You are preparing an informational brochure promoting your business.",
                    Index = 0,
                    Group = "3"
                },
                new Question()
                {
                    Title = "TASK 1",
                    Content = @"Below the heading <b>Our Most Popular Flavors!</b>, sort the table alphabetically from A to Z.",
                    Index = 1,
                    Group = "3",
                    Help = @"Below the heading Our Most Popular Flavors!, sort the table alphabetically from A to Z.
1. Below the heading ""Our Most Popular Flavors!"", select all of the rows in the table.
2. Click the TABLE TOOLS LAYOUT tab.
3. In the Data group, click Sort.
4. In the Sort pop-up window, in the sort by drop down ensure it says column 1. Accept the defaults.
5. Click OK."
                },
                new Question()
                {
                    Title = "TASK 2",
                    Content = @"Below the heading <b>Key Clients</b>, convert the text <b>The Party People … I Scream, U Scream</b> to a list with <b>default bullets.</b>",
                    Index = 2,
                    Group = "3",
                    Help = @"1. Below the heading Key Clients, select the text beginning with The Party People and ending with I Scream, U Scream.
2. Click the HOME tab.
3. In the Paragraph group, click the Bullets button."
                },
                new Question()
                {
                    Title = "TASK 3",
                    Content = @"On the cover of the brochure, <b>draw a textbox</b> between the title, <b>Ice Cream Shop</b> and the <b>graphic</b>. Inside the textbox, type the text <b>We specialize in custom flavors!</b>",
                    Index = 3,
                    Group = "3",
                    Help = @"On the cover of the brochure, draw a textbox between the title, Ice Cream Shop and the graphic. Inside the textbox, type the text We specialize in custom flavors!
1. Place your cursor in the empty space below the title, Ice Cream Shop.
2. Click the INSERT tab.
3. In the Text group, click Text Box.
4. At the bottom of the Builtin pop-up window, select Draw Text Box. Using the cursor, draw a box big enough to hold the text
(Hint: approximately the length of the title, Ice Cream Shop)
5. Inside the box type the text, We specialize in custom flavors!
6. Click anywhere outside the textbox to deselect it."
                },
                new Question()
                {
                    Title = "TASK 4",
                    Content = @"Apply the <b>Inner Shadow Effect, Inside: Top Left</b> to the <b>ice cream graphic</b> on the cover of the brochure.",
                    Index = 4,
                    Group = "3",
                    Help = @"1. Click on the graphic of the Ice Cream Cone to select it.
2. On the PICTURE TOOLS FORMAT tab, in the Picture Styles group, click Picture Effects.
3. Select Shadow and under the Inner section select Inside: Top Left."
                },
                new Question()
                {
                    Title = "TASK 5",
                    Content = @"Apply the <b>Off Axis 1 Right 3-D Rotation Parallel</b> effect to the picture on the <b>second page.</b>",
                    Index = 5,
                    Group = "3",
                    Help = @"1. On the second page, click on the graphic of the Ice Cream Sundae to select it.
2. On the PICTURE TOOLS FORMAT tab, in the Picture Styles group, click Picture Effects.
3. In the Picture Effects drop-down menu, select 3-D Rotation. In the section Parallel, select Off Axis 1 Right."
                },
                new Question()
                {
                    Title = "OVERVIEW",
                    Content = @"<h2>Rock Crawling</h2>
You are preparing a report on popular Rock Crawling sites located in nearby mountain regions.",
                    Index = 0,
                    Group = "4"
                },
                new Question()
                {
                    Title = "TASK 1",
                    Content = @"On page 2, <b>bookmark</b> the heading <b>Moab, Utah.</b> Name the bookmark <b>Moab.</b>",
                    Index = 1,
                    Group = "4",
                    Help = @"1. On page 2, place your cursor to the left of the heading, Moab, Utah.
2. On the INSERT tab, in the Links group, click Bookmark.
3. In the Bookmark pop-up box, in the top field type the name, Moab.
4. Click Add."
                },
                new Question()
                {
                    Title = "TASK 2",
                    Content = @"<b>Simultaneously</b> replace all text, <b>climbing</b> with <b>crawling.</b>",
                    Index = 2,
                    Group = "4",
                    Help = @"1. On the HOME tab, in the Editing group, click Replace.
2. In the Find and Replace pop-up window, on the Replace tab, configure the following:
Find what: climbing
Replace with: crawling
3. Click Repace All (Hint: 2 replacements should have been made.) Click OK.
4. Click Close to exit the Find and Replace pop-up window."
                },
                new Question()
                {
                    Title = "TASK 3",
                    Content = @"On the bottom of <b>page 2</b>, create a table from the text <b>Mountain Locations … Depending on equipment).</b> Create the table with <b>2 columns.</b> (Accept all other defaults)",
                    Index = 3,
                    Group = "4",
                    Help = @"1. On page 2, select the text, Mountain Locations … Depending on equipment).
2. On the INSERT tab, in the Tables group, click Table and select Convert Text to Table …
3. In the Convert Text to Table pop-up window, configure the table size to:
Number of columns: 2
(Accept all other defaults)
4. Click OK."
                },
                new Question()
                {
                    Title = "TASK 4",
                    Content = @"In <b>page 1</b>, change the bullets of the first list to a <b>solid circle</b> to match the other list.",
                    Index = 4,
                    Group = "4",
                    Help = @"1. Select all the first list, Jeep and varients … Mercedes Unimog.
2. On the HOME tab, in the Paragraph group, click the Bullets down-arrow.
3. In the Bullet Library, select the solid circle."
                },
                new Question()
                {
                    Title = "TASK 5",
                    Content = @"Add the cover page, <b>Integral.</b>",
                    Index = 5,
                    Group = "4",
                    Help = @"1. At the top of the first page, place your cursor above the heading, Rock Crawling!
2. On the INSERT tab, in the Pages group, click Cover Page.
3. Scroll down and select Integral."
                },
                new Question()
                {
                    Title = "OVERVIEW",
                    Content = @"<h2>Fishing</h2>
Your family owns a small bait and tackle shop next to a lake popular for its fishing. You are preparing a quarterly newletter for your fishing customers.",
                    Index = 0,
                    Group = "5"
                },
                new Question()
                {
                    Title = "TASK 1",
                    Content = @"Create 2 columns using the text <b>Fishing Derby a Success … local fish enhancement.</b> Make the columns 2.85"" (7.24 cm) wide with spacing between the columns of <b>0.3"" (0.76 cm).</b> (Accept all other defaults)",
                    Index = 1,
                    Group = "5",
                    Help = @"1. Select the text beginning with the heading, Fishing Derby a Success, through the end of the third paragrah, ... local fish enhancement.
2. On the LAYOUT tab, in the Page Setup group, click Columns and select More Columns…
3. In the Columns pop-up box, change the following:
Number of columns: 2
Width: 2.85"" (7.24 cm)
Spacing: 0.3"" (0.76 cm)
Accept all other defaults.
4.Click OK."
                },
                new Question()
                {
                    Title = "TASK 2",
                    Content = @"Apply the style <b>Grid Table 5 Dark - Accent 5</b> to the table on the <b>second page.</b>",
                    Index = 2,
                    Group = "5",
                    Help = @"1. On the second page, select the table by clicking the table selector in the upper-left corner of the table (the + symbol).
2. Select the TABLE TOOLS DESIGN tab.
3. In the Table Styles group, click the More drop-down arrow to open the gallery.
4. Select the Grid Table 5 Dark - Accent 5 style."
                },
                new Question()
                {
                    Title = "TASK 3",
                    Content = @"Insert an endnote on the <b>second page</b> that reads,<b> Oregon fishing license required</b>. Reference the endnote from the last sentence in the first paragraph, <b>…fabulous all year!</b> Use the endnote number format: <b>1,2,3 …</b>",
                    Index = 3,
                    Group = "5",
                    Help = @"1. On the second page, place your cursor to the right of the last sentence in the first paragraph, ""…fabulous all year!""
2. Click the REFERENCES tab.
3. In the Footnotes group, click the Footnote & Endnote dialog box launcher located in the lower-right corner of the group.
4. In the Footnote and Endnote pop-up window, configure the following:
a. Below the Location section select Endnotes:
b. To the right of Endnotes: click the drop-down menu and select End of document.
c. Below the Format section, click the drop-down menu to change the Number format: to 1,2,3, ...
(Accept all other defaults)
d. Click Insert.
5. In the Endnote type, Oregon fishing license required."
                },
                new Question()
                {
                    Title = "TASK 4",
                    Content = @"On the <b>second page</b> below the <b>Plan a Trip</b> heading, enhance the graphic by applying <b>Colorful Range - Accent Colors 5 to 6.</b>",
                    Index = 4,
                    Group = "5",
                    Help = @"1. On the second page below the Plan a Trip heading, click the SmartArt graphic to select it.
2. Select the SMARTART TOOLS DESIGN tab.
3. In the SmartArt Styles group, click Change Colors.
4. Below the Colorful section, select Colorful Range - Accent Colors 5 to 6."
                },
                new Question()
                {
                    Title = "TASK 5",
                    Content = @"Add the text, <b>Catch a Fish!</b> to the last shape of the graphic on the <b>second page.</b>",
                    Index = 5,
                    Group = "5",
                    Help = @"1. On the second page below the Plan a Trip heading, click inside the empty shape of the SmartArt.
2. Type the text, Catch a Fish!
3. Click anywhere outside the graphic to deselect it."
                },
                new Question()
                {
                    Title = "OVERVIEW",
                    Content = @"<h2>FusionTomo</h2>
You have been tasked with updating the informational pamphlet that business-technology company FusionTomo sends out to prospective clients.",
                    Index = 0,
                    Group = "6"
                },
                new Question()
                {
                    Title = "TASK 1",
                    Content = @"Display the <b>paragraph marks</b> on the document.",
                    Index = 1,
                    Group = "6",
                    Help = @"1. On the HOME tab, in the Paragraph group, click the pilcrow ( ¶ ) symbol."
                },
                new Question()
                {
                    Title = "TASK 2",
                    Content = @"Remove all of the <b>Document Properties</b> and <b>Personal Information</b> from the flyer. Leave all other hidden properties.",
                    Index = 2,
                    Group = "6",
                    Help = @"1. Select the FILE tab.
2. In the Info pane, click Check for Issues and select Inspect Document.
3. In the Document Inspector pop-up window, accept all defaults and click Inspect.
4. Next to Document Properties and Personal Information, click Remove All.
5. Click Close."
                },
                new Question()
                {
                    Title = "TASK 3",
                    Content = @"Put the <b>quote</b> at the bottom of the last page from <b>Craig Stronin</b> into the <b>textbox</b> located below it.",
                    Index = 3,
                    Group = "6",
                    Help = @"1. At the bottom of the last page, select the text, Business is ... FusionTomo CEO (include the quotes).
2. On the HOME tab, in the Clipboard group, click Cut (scissors icon). (Hint: You can also use the short-cut key, CTRL+X)
3. Place your cursor inside the textbox.
4. In the Clipboard group, click Paste. (Hint: You can also use the short-cut key, CTRL+V)."
                },
                new Question()
                {
                    Title = "TASK 4",
                    Content = @"On the first <b>page</b>, apply the <b>Strong font style</b> to the four list items <b>Vision, Reliability, Adaptability,</b> and <b>Family.</b>",
                    Index = 4,
                    Group = "6",
                    Help = @"1. On the first page, hold down the CTRL key and select the four list items ""Vision"", ""Reliability"", ""Adaptability"", and ""Family"".
2. With the four list items selected, on the HOME tab, in the Styles group, click the More down-arrow to open the gallery.
3. Click Strong."
                },
                new Question()
                {
                    Title = "TASK 5",
                    Content = @"On the <b>first page</b>, change the width of the table column <b>Purpose</b> to 1.8"".",
                    Index = 5,
                    Group = "6",
                    Help = @"1. On the first page, select only the column in the table with the heading Purpose.
2. Select the TABLE TOOLS LAYOUT tab.
3. In the Cell Size group, change the Width to 1.8""."
                },
                new Question()
                {
                    Title = "OVERVIEW",
                    Content = @"Scuba
You own a small SCUBA diving concession in the Caribbean. You are creating a flyer to advertise your next dive class.",
                    Index = 0,
                    Group = "7"
                },
                new Question()
                {
                    Title = "TASK 1",
                    Content = @"Change the <b>Status</b> property of the document to <b>Draft.</b>",
                    Index = 1,
                    Group = "7",
                    Help = @"1. Select the FILE tab.
2. In the lower right corner of the Properties pane, click Show All Properties.
3. Insert your cursor in the Status property field and type, Draft.
4. Click anywhere outside the field to confirm it."
                },
                new Question()
                {
                    Title = "TASK 2",
                    Content = @"In the endnote, replace the word <b>Section</b> with its <b>Special Character.</b>",
                    Index = 2,
                    Group = "7",
                    Help = @"1. In the endnote located at the bottom of the flyer, select the text ""Section"".
2. Click the INSERT tab.
3. In the Symbols group, click Symbols and at the bottom click More Symbols ...
4. In the Symbols pop-up window, select the Special Characters tab.
5. Select the Section character and click Insert.
6. Click Close."
                },
                new Question()
                {
                    Title = "TASK 3",
                    Content = @"Increase the <b>font size</b> of the document one level.",
                    Index = 3,
                    Group = "7",
                    Help = @"1. Select the text in the entire document by triple-clicking in the left margin.
2. Click the HOME tab.
3. In the Font group, click the Increase Font Size icon once."
                },
                new Question()
                {
                    Title = "TASK 4",
                    Content = @"Remove all formatting from the endnote <b>As per … 101-12-37(b)</b>",
                    Index = 4,
                    Group = "7",
                    Help = @"1. At the bottom of the flyer, select the text in the endnote. (Hint: Select only the text, not the endnote reference symbol.)
2. Click the HOME tab.
3. In the Font group, click Clear All Formatting. (Hint: The icon looks like an eraser with an A behind it.)"
                },
                new Question()
                {
                    Title = "TASK 5",
                    Content = @"Convert the text <b>Discover Scuba</b> to <b>WordArt Fill - Blue, Accent 1, Shadow</b>. Position the WordArt centered <b>above the photo.</b>",
                    Index = 5,
                    Group = "7",
                    Help = @"1. Select the text, Discover Scuba.
2. Click the INSERT tab.
3. In the Text group, click WordArt to open the gallery.
4. Select Fill - Blue, Accent 1, Shadow.
5. On the DRAWING TOOLS FORMAT tab, in the Arrange group, click Align and select Align Center.
6. Click anywhere outside the WordArt to deselect it."
                },
            };
            test_1_office_2016.Questions = questions;

            using (var db = new LiteDatabase(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.db")))
            {
                db.DropCollection("tests");
                db.DropCollection("tasks");
                ILiteCollection<Test> collection = db.GetCollection<Test>("tests");
                collection.EnsureIndex("Name");
                collection.Insert(test_1_office_2013);
                collection.Insert(test_1_office_2016);
            }
        }
    }
}
