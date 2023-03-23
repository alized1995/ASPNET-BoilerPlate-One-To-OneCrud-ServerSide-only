import { OneToOneCrudTemplatePage } from './app.po';

describe('OneToOneCrud App', function() {
  let page: OneToOneCrudTemplatePage;

  beforeEach(() => {
    page = new OneToOneCrudTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
