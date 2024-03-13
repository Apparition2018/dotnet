## [了解 Web 可访问性的基础知识](https://learn.microsoft.com/zh-cn/training/modules/web-development-101-accessibility/)
### 不仅仅使用浏览器上网
- [Microsoft Edge 中的辅助功能](https://support.microsoft.com/zh-cn/microsoft-edge/microsoft-edge-%E4%B8%AD%E7%9A%84%E8%BE%85%E5%8A%A9%E5%8A%9F%E8%83%BD-4c696192-338e-9465-b2cd-bd9b698ad19a)
### 使用开发者工具确保可访问性
- 对比检查
    - 调色板生成工具
        - [Adobe Color](https://color.adobe.com/zh/create/color-accessibility)
        - [Color Safe](http://colorsafe.co/)
    - 合规性检查工具
        - 测试页面的浏览器扩展
            - [Edge: WCAG Color contrast checker](https://microsoftedge.microsoft.
              com/addons/detail/wcag-color-contrast-check/idahaggnlnekelhgplklhfpchbfdmkjp)
            - [Firefox: WCAG Contrast checker](https://addons.mozilla.org/zh-CN/firefox/addon/wcag-contrast-checker/)
            - [Chrome: Colour Contrast Checker](https://chromewebstore.google.
              com/detail/colour-contrast-checker/nmmjeclfkgjdomacpcflgdkgpphpmnfe)
        - 应用程序：[Colour Contrast Analyser (CCA)](https://www.tpgi.com/color-contrast-checker/)
- Lighthouse：Google 研发的网站分析工具，已添加至许多浏览器的开发者工具中。Lighthouse 可以检查页面的搜索引擎优化 (SEO)、负载性能和其他最佳做法。 Lighthouse 还可分析页面，并为页面当前的可访问性打分。
### 确保链接和图像可供访问
- 链接文本
```html
<!-- 错误示范 -->
<p>小企鹅有时又称神仙企鹅，是世界上体型最小的企鹅。 详情请<a href="https://en.wikipedia.org/wiki/Little_penguin">单击此处</a></p>
<p>小企鹅有时又称神仙企鹅，是世界上体型最小的企鹅。 详情请访问<a href="https://en.wikipedia.org/wiki/Little_penguin">https://en.wikipedia.org/wiki/Little_penguin</a></p>
<!-- 正确示范 -->
<p><a href="https://en.wikipedia.org/wiki/Little_penguin">小企鹅</a>有时又称神仙企鹅，是世界上体型最小的企鹅。</p>
```
- [ARIA](https://developer.mozilla.org/zh-CN/docs/Web/Accessibility/ARIA)
- 图像的替换文本
```html
<img src="" alt="demo">
```
### 无障碍设计

### Reference
- [microsoft/Web-Dev-For-Beginners](https://github.com/microsoft/Web-Dev-For-Beginners)
---
