using UnityEngine;

/// <summary>
/// MIT License
///
/// Copyright (c) 2016 - 2019 GitHub
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
///
/// The above copyright notice and this permission notice shall be included in all
/// copies or substantial portions of the Software.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
/// SOFTWARE.
/// </summary>

/// <summary>
/// Unity project made by Marcus Aas Jensen.
/// You can share this project as long as you mention my complete name in one of the files project.
/// If you encounter any major bugs or issues by using this project, you can contact me via my email: aasjensenm@gmail.com
/// 
/// You can support me by following me on
/// Youtube: https://www.youtube.com/MarcusAasJensen_
/// Instagram: https://www.instagram.com/marcus_aasjensen
/// Github: https://github.com/marcusaasjensen
/// Itchio: https://marcus-a.itch.io
/// 
/// Or, you can simply share this hyperlink to my linktree
/// https://linktr.ee/marcus_a
/// 
/// Stay curious as platypuses!
/// </summary>

[DisallowMultipleComponent]
public class ByMarcusAasJensen : MonoBehaviour
{
    public readonly string linktreeLink = "https://linktr.ee/marcus_a";
    public readonly string youtubeLink = "https://www.youtube.com/MarcusAasJensen_";
    public readonly string instagramLink = "https://www.instagram.com/marcus_aasjensen";
    public readonly string githubLink = "https://github.com/marcusaasjensen";
    public readonly string itchioLink = "https://marcus-a.itch.io";
    private void Start() => this.gameObject.SetActive(false);
}